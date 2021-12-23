using DAL;
using DTO;
using HebrewNLP.Morphology;
using HebrewNLP.Names;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Algorithm
    {
        AutomaticClassificationDBEntities db = new AutomaticClassificationDBEntities();

        //הסרת מילים לא רלוונטיותתת


        float[,] probability_mat;   //A matrix that contains in each cell the probability of a word to belong to a specific category.
        float[] categoryProbability_arr;  //An array that contains in each cell the probability of its face belonging to each category.
        RequestAnalysis req_Analysis;    //Object containing the request analysis.

        public Algorithm()
        {
            probability_mat = new float[db.Word_tbl.Count(), db.Category_tbl.Count()];
            categoryProbability_arr = InitProbability_arr();
            req_Analysis = new RequestAnalysis();
        }

        /// <summary>
        /// The function gets a new mail and move the email from an inbox to the selected category folder.
        /// </summary>
        /// <param name="subject">email subject</param>
        /// <param name="body">email body</param>
        /// <param name="sender">email sender</param>
        /// <param name="date">email date</param>
        public void NewEmailRequest(string subject, string body, string sender, DateTime date)
        {
            EmailRequest request = new EmailRequest(subject, body, sender, date);
            request.ID_category = AssociateRequestToCategory(request);
            //העברת המייל מתיבת דואר נכנס לתקיית הקטגוריה שנבחרה
            db.EmailRequest_tbl.Add(request.DtoTODal());
            db.SaveChanges();
        }


        /// <summary>
        /// The function associates the email request to category.
        /// </summary>
        /// <param name="request">email request</param>
        /// <returns>id of the most suitable category</returns>
        public int AssociateRequestToCategory(EmailRequest request)
        {
            SubjetcAnalysis(request.EmailSubject);
            BodyAnalysis(request.EmailContent);
            BuildProbabilityMat();

            return 1;  //צריך להחזיר את הקטגוריה
        }


        /// <summary>
        /// Analysis of the subject of the email
        /// </summary>
        /// <param name="subject">email subject</param>
        public void SubjetcAnalysis(string subject)
        {
            string[] subject_arr = StringToArray(subject);
            req_Analysis.NamesInSubject = NameRecognitionByHebrewNLP(subject_arr);
            //להסיר מהמשפט את כל המילים שזוהו כשמות
            req_Analysis.NormalizedSubjectWords = NormalizeWordsByHebrewNLP(subject_arr);
            //if (normalizedSubjectWords[7]=="רכש")     //somthing wrong...
            //{
            //    Console.WriteLine("hiiiii");
            //}
        }


        /// <summary>
        /// The function analyzes the body of the email.
        /// </summary>
        /// <param name="body">email body</param>
        public void BodyAnalysis(string body)
        {
            List<string> bodySplitToSentences = SplitToSentencesByHebrewNLP(body);
            req_Analysis.bodyAnalysis = new BodyContent[bodySplitToSentences.Count()];
            int i = 0;
            int numCategories = db.Category_tbl.Count();
            foreach (var sentence in bodySplitToSentences)
            {
                req_Analysis.bodyAnalysis[i] = new BodyContent(numCategories);
                req_Analysis.bodyAnalysis[i].NamesInBody = NameRecognitionByHebrewNLP(StringToArray(sentence));
                //צריך להסיר את כל השמות  שזוהו מהמשפט
                req_Analysis.bodyAnalysis[i++].NormalizedBodyWords = NormalizeWordsByHebrewNLP(StringToArray(sentence));
            }
        }


        /// <summary>
        /// The function converts a string to an array, each word in a string = cell in the array.
        /// </summary>
        /// <param name="sentence">any string</param>
        /// <returns>An array</returns>
        public string[] StringToArray(string sentence)
        {
            char[] separators = new char[] { ' ', '\n', '\t', '\r' };
            return sentence.Split(separators);     //take out the separators.
        }


        /// <summary>
        /// The function splits the string into a list of sentences by using the library HebrewNLP.
        /// </summary>
        /// <param name="allBody">email body</param>
        /// <returns>List of sentences</returns>
        public List<string> SplitToSentencesByHebrewNLP(string allBody)
        {
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            List<string> bodySplitToSentences = HebrewNLP.Sentencer.Sentences(allBody);
            return bodySplitToSentences;
        }


        /// <summary>
        /// The function normalizes each word to its original form by using the HebrewNLP directory.
        /// </summary>
        /// <param name="words_arr">Receives an array of strings</param>
        /// <returns>A list of strings containing the words normalized</returns>
        public List<string> NormalizeWordsByHebrewNLP(string[] words_arr)
        {
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            return HebrewMorphology.NormalizeWords(words_arr, NormalizationType.SEARCH);
        }


        /// <summary>
        /// The function analyzes the sentence and recognize names using the HebrewNLP library.
        /// </summary>
        /// <param name="sentence_arr">sentence (as an array)</param>
        /// <returns>A list of strings containing the names recognized in the sentence</returns>
        public List<string> NameRecognitionByHebrewNLP(string[] sentence_arr)
        {
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            List<NameInfo> options = NameAnalyzer.Analyze(sentence_arr);
            return ReturnOnlyNames(options, sentence_arr);
        }


        /// <summary>
        /// The function maps the names from the list.
        /// </summary>
        /// <param name="options">List of NameInfo</param>
        /// <param name="sentence_arr"></param>
        /// <returns>A list of strings containing the names from the sentence</returns>
        public List<string> ReturnOnlyNames(List<NameInfo> options, string[] sentence_arr)
        {
            int i = 0;
            List<string> onlyNames = null;
            //if (options == null)
            //    return onlyNames;
            foreach (var word in options)
            {
                if (word.FirstName > 6 || word.LastName > 6)
                    onlyNames.Add(sentence_arr[i]);
                i++;
            }
            return onlyNames;
        }


        /// <summary>
        /// The function build the matrix of probabilities. In each cell in the matrix we put the probability of this word to belong to a certain category.
        /// </summary>
        public void BuildProbabilityMat()
        {
            List<WordPerCategory_tbl> wpc_lst = db.WordPerCategory_tbl.ToList();
            for (int i = 0; i < wpc_lst.Count(); i++)
                probability_mat[wpc_lst[i].ID_word - 1, wpc_lst[i].ID_category - 1] = (float)wpc_lst[i].MatchPercentage; //קוד המילה/ הקטגוריה הוא המיקום של המילה/ הקטגוריה ברשימה שלהם- כי זה מספור אוטומטי רודף.
        }


        /// <summary>
        /// The function calculates for each category the probability of the email request to belong to it.
        /// </summary>
        /// <param name="contentWords_lst">A list of strings containing the words from the email request.</param>
        /// <returns>An array that contains for each category its probability of belonging to this a category.</returns>
        public float[] CalcProbabilityForCategory(List<string> contentWords_lst)
        {
            Dictionary<string, int> words_dictionary = GetRelevantWordsAsDictionary(contentWords_lst);
            //int key = -1;
            int id_word;
            float prob_similiarWords = 0;
            //        //לבדוק האם מילה קיימת בדטה בייס. אם כן- להכפיל בערך של המיקום שלו במטריצה. אם לא- לבדוק באתר מילים דומות. ואם גם זה לא להכפיל ב- 0.0001
            foreach (var word in contentWords_lst)
            {
                //key = FindKeyByValue(words_dictionary, word);
                id_word = 0;
                bool isExsist = words_dictionary.TryGetValue(word, out id_word);
                for (int i = 0; i < categoryProbability_arr.Length; i++)
                {
                    if (!isExsist /*|| probability_mat[id_word-1 , i]==0*/)
                    {
                        prob_similiarWords = SimiliarWords_probability(word);
                        if (prob_similiarWords == 0)
                            prob_similiarWords = 0.0001f;
                        categoryProbability_arr[i] *= prob_similiarWords;
                    }
                    else
                        categoryProbability_arr[i] *= probability_mat[id_word - 1, i];
                }
            }
            return categoryProbability_arr;
        }


        /// <summary>
        /// Function initializes the array of categories - for each category the number of email requests sent to this category.  
        /// arr[i]= P(c).  We will not make the division into the general number of email requests because this division is equal for all categories and there is no point in doing so.
        /// </summary>
        /// <returns>The array of probabilities - for each category the probability of the email requests to belong to it.</returns>
        public float[] InitProbability_arr()
        {
            float[] probability_arr = new float[db.Category_tbl.Count()];
            for (int i = 0; i < probability_arr.Length; i++)
            {
                int numRequestsForCategory = db.EmailRequest_tbl.Where(e => e.ID_category == i).Count();
                probability_arr[i] = numRequestsForCategory;
            }
            return probability_arr;
        }

        /// <summary>
        /// A function that converts a list to a dictionary
        /// </summary>
        /// <param name="words_lst">A list of words that exist in the email request</param>
        /// <returns>A dictionary that contains only words that exist in the application</returns>
        public Dictionary<string, int> GetRelevantWordsAsDictionary(List<string> words_lst)
        {
            var allWords_lst = db.Word_tbl.ToList();
            var dic = allWords_lst.ToDictionary(x => x.Value_word, x => x.ID_word)/*.Where(y => words_lst.Contains(y.Key))*/;
            return /*(Dictionary<string, int>)*/dic;
        }

        public float SimiliarWords_probability(string word)
        {
            //על המילים הדומות שמקבלים צריך לבדוק שוב האם קיימות ב-דטה בייס לקטגוריה זו, ולהחזיר את ההסתברות, אם לא קיימות  להחזיר 0
        }

        public int IndexMaxProbability(float[] probability_arr)  //לא השתמשתי עדיין
        {
            //צריך להחזיר את המקס
            //אם יש כמה קטגוריות שקרובות למקס, צריך לבצע בדיקות נוספות לדוגמא: אנשי קשר
        }
    }
}
