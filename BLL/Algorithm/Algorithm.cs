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
        AutoClassificationDBEntities db = AutoClassificationDBEntities.Instance;


        float[,] probability_mat;   //A matrix that contains in each cell the probability of a word to belong to a specific category.
        float[] categoryProbability_arr;  //An array that contains in each cell the probability of its face belonging to each category.
        RequestAnalysis req_Analysis;    //Object containing the request analysis.
        Dictionary<string, Word_tbl> allWords;

        public Algorithm()
        {
            probability_mat = new float[db.Word_tbl.Count(), db.Category_tbl.Count()];
            categoryProbability_arr = InitProbability_arr();
            req_Analysis = new RequestAnalysis();
            allWords = GetAllWordsAsDictionary();
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
            Conclusion conclusion = new Conclusion(req_Analysis);
            conclusion.LearningForNext((int)request.ID_category, allWords);
            conclusion.AddEmailRequest_tbl(request.DtoTODal());
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
            if (IsTherewordInSentence(subject_arr))
            {
                req_Analysis.NamesInSubject = NameRecognitionByHebrewNLP(subject_arr);
                subject_arr = RemoveNamesFromSentence(subject_arr.ToList(), req_Analysis.NamesInSubject);  //הסרה השמות שזוהו מהנושא
                req_Analysis.NormalizedSubjectWords = NormalizeWordsByHebrewNLP(subject_arr);
                req_Analysis.NormalizedSubjectWords = RemoveIrrelevantWords(req_Analysis.NormalizedSubjectWords);
            }
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
            int i = 0, numCategories = db.Category_tbl.Count();
            string[] sentenceInBody_arr = null;
            foreach (var sentence in bodySplitToSentences)
            {
                req_Analysis.bodyAnalysis[i] = new BodyContent(numCategories);
                sentenceInBody_arr = StringToArray(sentence);
                if (IsTherewordInSentence(sentenceInBody_arr))
                {
                    req_Analysis.bodyAnalysis[i].NamesInBody = NameRecognitionByHebrewNLP(sentenceInBody_arr);      //הסרה השמות שזוהו במשפט זה
                    sentenceInBody_arr = RemoveNamesFromSentence(sentenceInBody_arr.ToList(), req_Analysis.bodyAnalysis[i].NamesInBody);
                    req_Analysis.bodyAnalysis[i].NormalizedBodyWords = NormalizeWordsByHebrewNLP(sentenceInBody_arr);
                    req_Analysis.bodyAnalysis[i].NormalizedBodyWords = RemoveIrrelevantWords(req_Analysis.bodyAnalysis[i].NormalizedBodyWords);
                    i++;
                }
            }
        }

        public bool IsTherewordInSentence(string[] sentence)
        {
            if (sentence.Count() == 0)
                return false;
            foreach (var word in sentence)
            {
                if (word != "")
                    return true;
            }
            return false;
        }

        /// <summary>
        /// A function that removes prepositions and belonging from the list. (All irrelevant words will be removed from the email request)
        /// </summary>
        /// <param name="words_lst">words list</param>
        /// <returns>List of words without irrelevant words</returns>
        public List<string> RemoveIrrelevantWords(List<string> words_lst)
        {
            words_lst.RemoveAll(item =>  allWords.ContainsKey(item) && allWords[item].ID_wordType == 2);
            return words_lst;
            //problemmm
            //המילה אייטם מנוקדת ועם אותיות סופיות רגילות
            //איך אני יכולה לבדוק האם קיים לי ב-דטה בייס  מילה כזו ללא ניקוד ועם אותיות מנצפך.

            //bool result = root.Equals(root2, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// The function removes the list list names from the sentence list.
        /// </summary>
        /// <param name="sentence">sentence list</param>
        /// <param name="names">names list</param>
        /// <returns>Array containing the sentence list after mapping (after removal)</returns>
        public string[] RemoveNamesFromSentence(List<string> sentence, List<string> names)
        {
            sentence.RemoveAll(item => names.Contains(item));
            return sentence.ToArray();
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
            List<NameInfo> options = null;
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            try
            {
                options = NameAnalyzer.Analyze(sentence_arr);
            }
            catch (Exception)
            {
                return ReturnOnlyNames(null, sentence_arr);
            }
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
            List<string> onlyNames = new List<string>();
            if (options == null)
                return onlyNames;
            foreach (var word in options)
            {
                if (word.FirstName > 7 || word.LastName > 7)
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
                probability_mat[wpc_lst[i].ID_word - 1,  wpc_lst[i].ID_category - 1] = (float)wpc_lst[i].MatchPercentage; //קוד המילה/ הקטגוריה הוא המיקום של המילה/ הקטגוריה ברשימה שלהם- כי זה מספור אוטומטי רודף.
        }


        /// <summary>
        /// The function calculates for each category the probability of the email request to belong to it.
        /// </summary>
        /// <param name="contentWords_lst">A list of strings containing the words from the email request.</param>
        /// <returns>An array that contains for each category its probability of belonging to this a category.</returns>
        public float[] CalcProbabilityForCategory(List<string> contentWords_lst)
        {
            Word_tbl word;
            float prob_similiarWords = 0;
            //לבדוק האם מילה קיימת בדטה בייס. אם כן- להכפיל בערך של המיקום שלו במטריצה. אם לא- לבדוק באתר מילים דומות. ואם גם זה לא להכפיל ב- 0.0001
            foreach (var w in contentWords_lst)
            {
                word = null;
                bool isExsist = allWords.TryGetValue(w, out word);
                for (int i = 0; i < categoryProbability_arr.Length; i++)
                {
                    if (!isExsist /*|| probability_mat[id_word-1 , i]==0*/)    //האם לבצע שליחה לאתר מילים דומות גם במקרה שהמילה קיימת בדטה בייס אך לא בקטגוריה זו?
                    {
                        prob_similiarWords = SimiliarWords_probability(w);
                        if (prob_similiarWords == 0)
                            prob_similiarWords = 0.0001f;
                        categoryProbability_arr[i] *= prob_similiarWords;
                    }
                    else
                        categoryProbability_arr[i] *= probability_mat[word.ID_word - 1, i];
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
        /// <returns>A dictionary that contains all DB words</returns>
        public Dictionary<string, Word_tbl> GetAllWordsAsDictionary()
        {
            var allWords_lst = db.Word_tbl.ToList();
            return allWords_lst.ToDictionary(x => x.Value_word, x => x);
        }

        public float SimiliarWords_probability(string word)
        {
            //על המילים הדומות שמקבלים צריך לבדוק שוב האם קיימות ב-דטה בייס לקטגוריה זו, ולהחזיר את ההסתברות, אם לא קיימות  להחזיר 0
            return 0;
        }

        public int IndexMaxProbability(float[] probability_arr)  //לא השתמשתי עדיין
        {
            //צריך להחזיר את המקס
            //אם יש כמה קטגוריות שקרובות למקס, צריך לבצע בדיקות נוספות לדוגמא: אנשי קשר
            return 0;
        }
    }
}
