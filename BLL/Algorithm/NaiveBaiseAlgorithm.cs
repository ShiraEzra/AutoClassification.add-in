using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public enum Percent { Body_VS_Subject = 50, Similiar = 40, Common = 60 }

    public class NaiveBaiseAlgorithm
    {
        readonly AutomaticClassificationDBEntities db = AutomaticClassificationDBEntities.Instance;
        float[,] probability_mat;   //A matrix that contains in each cell the probability of a word to belong to a specific category.
        readonly float[] firstInit_arr;      //An initialized array with the number of email requests for each category.
        RequestAnalysis req_Analysis;    //Object containing the request analysis.
        public static Dictionary<string, Word_tbl> allWords;   //All words from word_tbl as dictionary.
        const int numEndSentences = 3;

        public NaiveBaiseAlgorithm()
        {
            req_Analysis = new RequestAnalysis();
            allWords = GetAllWordsAsDictionary();
            firstInit_arr = FirstInitProbability_arr();
            BuildProbabilityMat();
        }


        /// <summary>
        /// The function receives an email request and the category to which it belongs.
        ///The function puts the data into the DB, to teach the system first.
        /// </summary>
        /// <param name="subject">email subject</param>
        /// <param name="body">email body</param>
        /// <param name="sender">email sender</param>
        /// <param name="date">email date</param>
        /// <param name="entryId">entryId of this mail</param>
        /// <param name="categoryName">the category to which this email request belongs</param>
        public string FirstInitDB_NewMail(string subject, string body, string sender, DateTime date, string entryId, string categoryName)
        {
            //EmailRequest_tbl request = db.EmailRequest_tbl.Single(er => er.ID_emailRequest == 4);
            EmailRequest_tbl request = new EmailRequest_tbl { EmailSubject = subject, EmailContent = body, SenderEmail = sender, Date = date, EntryId = entryId };
            request.ID_category = db.Category_tbl.FirstOrDefault(c => c.Name_category == categoryName)?.ID_category;
            SubjetcAnalysis(request.EmailSubject);
            BodyAnalysis(request.EmailContent);
            InsertConclusionToDB(request, false);
            return request.Category_tbl.Name_category;
        }


        /// <summary>
        /// The function gets a new mail and move the email from an inbox to the selected category folder.
        /// </summary>
        /// <param name="subject">email subject</param>
        /// <param name="body">email body</param>
        /// <param name="sender">email sender</param>
        /// <param name="date">email date</param>
        /// <param name="entryId">entryId of this mail</param>
        public string NewEmailRequest(string subject, string body, string sender, DateTime date, string entryId)
        {
            EmailRequest_tbl request = new EmailRequest_tbl { EmailSubject = subject, EmailContent = body, SenderEmail = sender, Date = date, EntryId = entryId };
            request.ID_category = AssociateRequestToCategory(request);
            InsertConclusionToDB(request, true);
            return request.Category_tbl.Name_category;
        }


        /// <summary>
        /// The function associates the email request to category.
        /// </summary>
        /// <param name="request">email request</param>
        /// <returns>id of the most suitable category</returns>
        public int AssociateRequestToCategory(EmailRequest_tbl request)
        {
            SubjetcAnalysis(request.EmailSubject);
            BodyAnalysis(request.EmailContent);
            CallFuncCalcProbabilityForAllPartsRequest();
            float[] totalProbability = TotalProbability();
            return IndexMaxProbability(totalProbability);  //צריך להחזיר את הקטגוריה
        }


        /// <summary>
        /// Call for a sentence analysis function from class Analysis.
        /// </summary>
        /// <param name="subject">email subject</param>
        public void SubjetcAnalysis(string subject)
        {
            subject = subject.RemoveOpeningWords();
            req_Analysis.NormalizedSubjectWords = subject.AnalysisSentece();
        }


        /// <summary>
        /// The function analyzes the body of the email, And calls a function analysis function from class Analysis.
        /// </summary>
        /// <param name="body">email body</param>
        public void BodyAnalysis(string body)
        {
            List<string> bodySplitToSentences = body.SplitToSentences();
            //לטפל במקרה שחוזר נאל= לא מצליח לגשת לספריית אןאלפי
            req_Analysis.BodyAnalysis = new BodyContent[(int)(bodySplitToSentences?.Count())];
            int i = 0, numCategories = db.Category_tbl.Count(), numSentences = bodySplitToSentences.Count();
            string s;
            foreach (var sentence in bodySplitToSentences)
            {
                s = sentence;
                if (i == 0)  //משפט פתיחה
                    s = sentence.RemoveOpeningWords();
                if (i > numSentences - numEndSentences) //שלושת המשפטים האחרונים- משפטי סיום
                    s = s.RemoveEndWords();
                req_Analysis.BodyAnalysis[i] = new BodyContent(numCategories);
                req_Analysis.BodyAnalysis[i].NormalizedBodyWords = s.AnalysisSentece();
                i++;
            }
        }


        /// <summary>
        /// The function goes through all the parts of the email request and sends each one separately to the function CalcProbabilityForCategory
        /// </summary>
        public void CallFuncCalcProbabilityForAllPartsRequest()
        {
            //זו הפונקציה שבמידת הצורך אחלק לתהליכונים
            req_Analysis.ProbabilitybSubjectForCategory = CalcProbabilityForCategory(req_Analysis.NormalizedSubjectWords, req_Analysis.ProbabilitybSubjectForCategory);
            foreach (var sentence in req_Analysis.BodyAnalysis)
                sentence.ProbabilitybSentenceForCategory = CalcProbabilityForCategory(sentence.NormalizedBodyWords, sentence.ProbabilitybSentenceForCategory);
        }


        /// <summary>
        /// The function build the matrix of probabilities. In each cell in the matrix we put the probability of this word to belong to a certain category.
        /// </summary>
        public void BuildProbabilityMat()
        {
            int max_IdWord = db.Word_tbl.Max(w => w.ID_word);
            int max_IdCategory = db.Category_tbl.Max(c => c.ID_category);
            probability_mat = new float[max_IdWord, max_IdCategory];
            List<WordPerCategory_tbl> wpc_lst = db.WordPerCategory_tbl.ToList();
            int wpc_count = wpc_lst.Count();
            int idWord, idCategory;
            for (int i = 0; i < wpc_count; i++)
            {
                idWord = wpc_lst[i].ID_word - 1;
                idCategory = wpc_lst[i].ID_category - 1;
                //קוד המילה/ הקטגוריה הוא המיקום של המילה/ הקטגוריה ברשימה שלהם- כי זה מספור אוטומטי רודף.
                probability_mat[idWord, idCategory] = (float)wpc_lst[i].AmountOfUse / firstInit_arr[idCategory];
            }
        }


        /// <summary>
        /// The function calculates for each category the probability of the sentence to belong to it.
        /// </summary>
        /// <param name="contentWords_lst">A list of strings containing the sentence.</param>
        /// <returns>An array that contains for each category its probability of belonging to this a category.</returns>
        public float[] CalcProbabilityForCategory(List<string> contentWords_lst, float[] categoryProbability_arr)
        {
            Word_tbl word;
            float prob_similiarWords, prob;
            //בעבור כל מילה הקיימת בדטה בייס - מחשבים את ההסתברות שלה + ההסתברות של המילים הדומות לה הקיימות ב-דטה בייס
            if (contentWords_lst.Count() == 0)
                InitProbability_arr(categoryProbability_arr, false);
            else
                InitProbability_arr(categoryProbability_arr, true);
            foreach (var w in contentWords_lst)
            {
                word = null;
                bool isExsist = allWords.TryGetValue(w, out word);
                for (int i = 0; i < categoryProbability_arr.Length; i++)
                {
                    prob_similiarWords = SimiliarWords_probability(w, i);
                    if (isExsist)
                        prob = probability_mat[word.ID_word - 1, i];
                    else
                        prob = 0.00001f;
                    prob = prob * ((float)Percent.Common) / 100 + prob_similiarWords * ((float)Percent.Similiar) / 100;   //משקל של 60% להסתברות של המילה עצמה, ו-40% להסתברות של המילים הדומות.
                    categoryProbability_arr[i] *= prob;
                }
            }
            return categoryProbability_arr;
        }


        /// <summary>
        /// If flag=true:  Function initializes the array of categories - with copies values as firstInit_arr   (istead of calculate it few times)
        /// If flag=false: Init arr to zero.
        /// </summary>
        /// <param name="probability_arr">arr</param>
        /// <param name="flag">init to num requests for category or init to 0</param>
        /// <returns>The array of probabilities - for each category the num of the email requests to belong to it, or array init to 0. it'w up to the flag </returns>
        public float[] InitProbability_arr(float[] probability_arr, bool flag)
        {
            probability_arr = new float[firstInit_arr.Length];
            if (flag)
                firstInit_arr.CopyTo(probability_arr, 0);
            //else    //לבדוק אם באמת צריך לאפס
            //    for (int i = 0; i < probability_arr.Length; i++)
            //        probability_arr[i] = 0;
            return probability_arr;
        }


        /// <summary>
        /// Function initializes the array of categories - for each category the number of email requests sent to this category.  
        /// arr[i]= P(c).  We will not make the division into the general number of email requests because this division is equal for all categories and there is no point in doing so.
        /// </summary>
        /// <returns>The array of probabilities - for each category the num of the email requests to belong to it.</returns>
        public float[] FirstInitProbability_arr()
        {
            float[] probability_arr = new float[db.Category_tbl.Count()];
            for (int i = 0; i < probability_arr.Length; i++)
            {
                int numRequestsForCategory = db.EmailRequest_tbl.Where(e => e.ID_category == i + 1).Count();
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


        /// <summary>
        /// Calculating the probability of words similar to the word.
        /// </summary>
        /// <param name="word">word</param>
        /// <param name="category_id">category id</param>
        /// <returns>the probability of words similar to the word</returns>
        public float SimiliarWords_probability(string word, int category_id)
        {
            //על המילים הדומות שמקבלים צריך לבדוק שוב האם קיימות ב-דטה בייס לקטגוריה זו, ולהחזיר את ההסתברות, אם לא קיימות  להחזיר 0
            List<string> similarWords = SimilarWords.GetSimilarWords(word);
            if (similarWords == null)
                return 0;
            List<string> normalizedSimWords = similarWords.ToArray().AnalysisWords();
            float prob = 0;
            int count = 0;
            foreach (var item in normalizedSimWords)
            {
                bool isExsist = allWords.TryGetValue(item, out Word_tbl wordFromDic);
                if (isExsist && probability_mat[wordFromDic.ID_word - 1, category_id] != 0)
                {
                    prob += probability_mat[wordFromDic.ID_word - 1, category_id];
                    count++;
                    req_Analysis.SimiliarwordsExsistDB.Add(wordFromDic);
                }
            }
            return prob / count;
        }


        /// <summary>
        /// The function calculates the total general probability for the email request for each category.
        /// </summary>
        /// <returns>Returns an array that contains for each category the final probability of the email request to belong to it.</returns>
        public float[] TotalProbability()
        {
            float[] totalProbability = new float[firstInit_arr.Length];   //צריך לאפס?
            for (int i = 0; i < totalProbability.Length; i++)
            {
                //חיבור ההסתברויות של כל המשפטים בגוף המייל
                foreach (var sentence in req_Analysis.BodyAnalysis)
                    totalProbability[i] += sentence.ProbabilitybSentenceForCategory[i];
                totalProbability[i] /= req_Analysis.BodyAnalysis.Count();
                totalProbability[i] *= ((float)Percent.Body_VS_Subject) / 100;  //gives 50% for the body
                //חיבור ההסתברות של גוף המייל עם הנושא
                totalProbability[i] += req_Analysis.ProbabilitybSubjectForCategory[i] * (((float)Percent.Body_VS_Subject) / 100);  //gives 50% for the subject
            }
            return totalProbability;
        }


        /// <summary>
        /// The function returns the index of the category with the highest probability.
        /// </summary>
        /// <param name="probability_arr">An array of probabilities for each category.</param>
        /// <returns>index of the category with the highest probability.</returns>
        public int IndexMaxProbability(float[] probability_arr)  //לא השתמשתי עדיין
        {
            //לראות אולי צריך לבצע בדיקה יותר חחכמה מחיפוש שרירותי אחר המקסימום
            //אם יש כמה קטגוריות שקרובות למקס, צריך לבצע בדיקות נוספות לדוגמא: אנשי קשר

            float maxValue = probability_arr.Max();
            for (int i = 0; i < probability_arr.Length; i++)
                if (probability_arr[i] == maxValue)
                    return i;
            return 0;
        }


        /// <summary>
        /// The function calls the functions of Conclusion class, in order to enter into the DB the data of the current email request for system improvement from now on.
        /// </summary>
        /// <param name="request">The emaill request</param>
        public void InsertConclusionToDB(EmailRequest_tbl request, bool isAutomat)
        {
            Conclusion conclusion = new Conclusion(req_Analysis, request, isAutomat);
            // conclusion.AddEmailRequest_tbl(request);
            conclusion.LearningForNext();
            conclusion.AddSendingHistory_tbl(-1);
        }
    }
}
