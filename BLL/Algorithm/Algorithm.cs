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
            List<List<MorphInfo>> analyzedSubject = AnalyzeSentence(subject);
            req_Analysis.NormalizedSubjectWords = RemoveIrrelevantWords(analyzedSubject);
        }


        /// <summary>
        /// The function analyzes the body of the email.
        /// </summary>
        /// <param name="body">email body</param>
        public void BodyAnalysis(string body)
        {
            List<string> bodySplitToSentences = SplitToSentences(body);
            req_Analysis.bodyAnalysis = new BodyContent[bodySplitToSentences.Count()];
            int i = 0, numCategories = db.Category_tbl.Count();
            foreach (var sentence in bodySplitToSentences)
            {
                req_Analysis.bodyAnalysis[i] = new BodyContent(numCategories);
                List<List<MorphInfo>> analyzedSentence = AnalyzeSentence(sentence);
                req_Analysis.bodyAnalysis[i].NormalizedBodyWords = RemoveIrrelevantWords(analyzedSentence);
                i++;
            }
        }


        /// <summary>
        /// The function removes the irrelevant words from the sentence.
        /// </summary>
        /// <param name="analyzedSentence">Analyzed sentence. (In addition - the word is normalized to the base form)</param>
        /// <returns>A list of strings containing the words relevant to the classification.</returns>
        public List<string> RemoveIrrelevantWords(List<List<MorphInfo>> analyzedSentence)
        {
            List<string> rellevantWords = new List<string>();
            foreach (var item in analyzedSentence)
            {
                MorphInfo firstword = item.FirstOrDefault();
                if (IsRrelavantPartOfSpeach(firstword))
                    rellevantWords.Add(firstword.BaseWordMenukad);
            }
            return rellevantWords;
        }


        /// <summary>
        /// The function checks whether the word is relevant according to the analysis of the word.
        /// </summary>
        /// <param name="morphInfo">Analyzed word</param>
        /// <returns>True- If the word is captivating and relevant. Otherwise - False</returns>
        public bool IsRrelavantPartOfSpeach(MorphInfo morphInfo)
        {
            if (morphInfo.PartOfSpeech == PartOfSpeech.VERB || morphInfo.PartOfSpeech == PartOfSpeech.NOUN || morphInfo.PartOfSpeech == PartOfSpeech.ADJECTIVE ||
                morphInfo.PartOfSpeech == PartOfSpeech.ADVERB || morphInfo.PartOfSpeech == PartOfSpeech.PROPER_NOUN)
                return true;
            return false;
        }

    
        /// <summary>
        /// The function splits the string into a list of sentences by using the library HebrewNLP.
        /// </summary>
        /// <param name="allBody">email body</param>
        /// <returns>List of sentences</returns>
        public List<string> SplitToSentences(string allBody)
        {
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            List<string> bodySplitToSentences = HebrewNLP.Sentencer.Sentences(allBody);
            return bodySplitToSentences;
        }


        /// <summary>
        /// The function analyzes the sentence.
        /// </summary>
        /// <param name="sentence">sentence</param>
        /// <returns>analyzed sentence   (as MorphInfo list)</returns>
        public List<List<MorphInfo>> AnalyzeSentence(string sentence)
        {
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            return HebrewMorphology.AnalyzeSentence(sentence);
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
