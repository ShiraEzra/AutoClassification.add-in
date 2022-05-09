using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public enum PercentCalcProb { MaxProbability = 1, Subject_VS_Body = 2, NameOfCategoryManager = 20, Similiar = 30, Common = 70, EmailContent = 80, Hundred = 100 }

    public class NaiveBaiseAlgorithm
    {
        readonly AutomaticClassificationDBEntities db = AutomaticClassificationDBEntities.Instance;
        public static Dictionary<string, Word_tbl> allWords;   //All words from word_tbl as dictionary.
        float[,] probability_mat;          //A matrix that contains in each cell the probability of a word to belong to a specific category.
        readonly float[] firstInit_arr;   //An initialized array with the number of email requests for each category.
        EmailRequest_tbl request;        //Object containing the request.
        RequestAnalysis req_Analysis;   //Object containing the request analysis.
        const int numOpenningSentence = 0, numEndingSentences = 3;
        const float justNotToReset = 0.00001f;

        public NaiveBaiseAlgorithm()
        {
            req_Analysis = new RequestAnalysis(db.Category_tbl.Count());
            //נפל בזמן ריצה בשורה הבאה - לבדוק למה
            allWords = db.Word_tbl.ToDictionary(x => x.Value_word, x => x);
            firstInit_arr = FirstInitProbability_arr();
            BuildProbabilityMat();
        }



        /// <summary>
        /// The function gets a new mail and move the email from an inbox to the selected category folder.
        /// (The category is selected by the <see cref="NaiveBaiseAlgorithm"></see>)
        /// </summary>
        /// <param name="subject">email subject</param>
        /// <param name="body">email body</param>
        /// <param name="sender">email sender</param>
        /// <param name="date">email date</param>
        /// <param name="entryId">entryId of this mail</param>
        public string NewEmailRequest(string subject, string body, string sender, DateTime date, string entryId)
        {
            request = new EmailRequest_tbl { EmailSubject = subject, EmailContent = body, SenderEmail = sender, Date = date, EntryId = entryId };
            request.ID_category = AssociateRequestToCategory() + 1;
            InsertConclusionToDB(true);
            return request.Category_tbl.Name_category;
        }


        /// <summary>
        /// The function associates the email request to category.
        /// </summary>
        /// <returns>id of the most suitable category</returns>
        public int AssociateRequestToCategory()
        {
            EmailRequestAnalysis();
            CallFuncCalcProbabilityForAllPartsRequest();
            double[] totalProbability = TotalProbability();
            return IndexMaxProbability(totalProbability);
        }


        /// <summary>
        /// The function analyzes the email (email request)
        /// </summary>
        public void EmailRequestAnalysis()
        {
            HandlingNamesOfCategoryManagerName();
            SubjetcAnalysis(request.EmailSubject);
            BodyAnalysis(request.EmailContent);
        }


        /// <summary>
        /// The function checks whether the email request mentions a request to one of the category managers.
        /// </summary>
        public void HandlingNamesOfCategoryManagerName()
        {
            if (request.EmailSubject == null)
                request.EmailSubject = "";
            if (!IsContainContent(request.EmailContent))
                request.EmailContent = "";
            string requestContent = request.EmailSubject + " " + request.EmailContent;
            char[] separators = new char[] { ' ', '\n', '\t', '\r', '-', ',', '.' };
            string[] wordsSentence = requestContent.Split(separators);     //take out the separators.
            var user_lst = db.User_tbl.ToList();
            foreach (var user in user_lst)
            {
                if (wordsSentence.Contains(user.Name))
                    req_Analysis.IsContainCategoryManagerID[(int)user.Categoty - 1] = true;
            }
        }


        /// <summary>
        /// The function checks whether the string it received contains real content, and not just spaces, etc.
        /// </summary>
        /// <param name="body">body of the email</param>
        /// <returns>True: if contains real content.  else - False</returns>
        public bool IsContainContent(string body)
        {
            if (body != null)
            {
                string onlyContent = body.Trim();
                if (onlyContent.Length > 1)
                    return true;
            }
            return false;
        }


        /// <summary>
        /// The function analyzes the subject of the email.
        /// </summary>
        /// <param name="subject">email subject</param>
        public void SubjetcAnalysis(string subject)
        {
            if (subject != "")
            {
                subject = subject.RemoveOpeningWords();
                subject = subject.RemoveEndingWords();
                req_Analysis.Subject.NormalizedSubjectWords = subject.AnalysisSentece();
            }
        }


        /// <summary>
        /// The function analyzes the body of the email.
        /// </summary>
        /// <param name="body">email body</param>
        public void BodyAnalysis(string body)
        {
            if (body != "")
            {
                List<string> bodySplitToSentences = body.SplitToSentences();
                bodySplitToSentences.RemoveAll(x => x.Length < 2);
                if (bodySplitToSentences.Count() == 0)   //In a case that fails to access the Hebrew NLP library
                    return;
                int i = 0, numSentences = bodySplitToSentences.Count();
                string s;
                foreach (var sentence in bodySplitToSentences)
                {
                    s = sentence;
                    if (i <= numOpenningSentence)  //משפט פתיחה
                        s = sentence.RemoveOpeningWords();
                    if (i >= numSentences - numEndingSentences) //שלושת המשפטים האחרונים- משפטי סיום
                        s = s.RemoveEndingWords();
                    if (s.Length > 1)  //שלא הוסר כל התוכן שלו
                    {
                        SentenceInBody sentenceInBody = new SentenceInBody();
                        sentenceInBody.NormalizedBodyWords = s.AnalysisSentece();
                        if (sentenceInBody.NormalizedBodyWords.Count() > 0)
                            req_Analysis.Body.Add(sentenceInBody);
                    }
                    i++;
                }
            }
        }


        /// <summary>
        /// The function goes through all the parts of the email request and sends each one separately to the function CalcProbabilityForCategory
        /// </summary>
        public void CallFuncCalcProbabilityForAllPartsRequest()
        {
            req_Analysis.Subject.ProbabilitybSubjectForCategory = CalcProbabilityForCategory(req_Analysis.Subject.NormalizedSubjectWords);
            int i = 0;
            List<Task<double[]>> tasks = new List<Task<double[]>>();
            foreach (var sentence in req_Analysis.Body)
            {
                Task<double[]> task = Task.Run(() => { return CalcProbabilityForCategory(sentence.NormalizedBodyWords); });
                tasks.Add(task);
            }
            foreach (var task in tasks)
            {
                task.Wait();
                req_Analysis.Body[i].ProbabilitybSentenceForCategory = task.Result;
                i++;
            }
        }


        /// <summary>
        /// The function calculates for each category the probability of the sentence to belong to it.
        /// </summary>
        /// <param name="contentWords_lst">A list of strings containing the sentence.</param>
        /// <returns>An array that contains for each category its probability of belonging to this a category.</returns>
        public double[] CalcProbabilityForCategory(List<string> contentWords_lst)
        {
            double[] categoryProbability_arr = InitProbability_arr();
            Task[] tasks = new Task[contentWords_lst.Count()];
            int indexArr = 0;
            //בעבור כל מילה הקיימת בדטה בייס - מחשבים את ההסתברות שלה + ההסתברות של המילים הדומות לה הקיימות ב-דטה בייס
            foreach (var w in contentWords_lst)
            {
                Task task = Task.Run(() =>
                {
                    float prob, prob_similiarWords;
                    bool isExsist = allWords.TryGetValue(w, out Word_tbl word);
                    List<string> similarWords = GetAnalayzedSimWords(w);
                    for (int i = 0; i < categoryProbability_arr.Length; i++)
                    {
                        prob_similiarWords = SimiliarWords_probability(i, similarWords, w);
                        if (isExsist && probability_mat[word.ID_word - 1, i] != 0)
                            prob = probability_mat[word.ID_word - 1, i];
                        else
                            prob = justNotToReset;
                        //משקל של 70% להסתברות של המילה עצמה, ו-30% להסתברות של המילים הדומות.
                        prob = prob * ((float)PercentCalcProb.Common) / (int)PercentCalcProb.Hundred + prob_similiarWords * ((float)PercentCalcProb.Similiar) / (int)PercentCalcProb.Hundred;
                        lock (categoryProbability_arr)
                        {
                            categoryProbability_arr[i] *= prob;
                        }
                    }
                });
                tasks[indexArr++] = task;
            }
            Task.WaitAll(tasks);
            return categoryProbability_arr;
        }


        /// <summary>
        /// Function initializes the array of categories - with copies values as firstInit_arr   (istead of calculate it few times)
        /// </summary>
        /// <returns>For each category the num of the email requests to belong to it</returns>
        public double[] InitProbability_arr()
        {
            double[] probability_arr = new double[firstInit_arr.Length];
            firstInit_arr.CopyTo(probability_arr, 0); //לברר שזה העתקה ממש, ולא רק הפניות
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
        /// The function build the matrix of probabilities.
        /// In each cell in the matrix we put the probability of this word to belong to a certain category.
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
        /// The function receives a word, and returns a list of analyzed words (by hebrew NLP) that are similar to it.
        /// </summary>
        /// <param name="w">A word</param>
        /// <returns>A list of analyzed words that are similar to it.</returns>
        public List<string> GetAnalayzedSimWords(string w)
        {
            List<string> simWords = SimilarWords.GetSimilarWords(w);
            if (simWords == null)
                return null;
            List<string> normalizedSimWords = simWords.ToArray().AnalysisWords();
            return normalizedSimWords;
        }


        /// <summary>
        /// Calculating the probability of words similar to the word.
        /// </summary>
        /// <param name="category_id">Category id</param>
        /// <param name="normalizedSimWords">List of similar words</param>
        /// <returns>The probability of the all words similar to the word together</returns>
        public float SimiliarWords_probability(int category_id, List<string> normalizedSimWords, string word)
        {
            //על המילים הדומות שמקבלים צריך לבדוק שוב האם קיימות ב-דטה בייס לקטגוריה זו, ולהחזיר את ההסתברות, אם לא קיימות  להחזיר 0
            if (normalizedSimWords == null)
                return 0;
            float prob = 0;
            int count = 0;
            foreach (var item in normalizedSimWords)
            {
                if (!item.Equals(word))
                {
                    bool isExsist = allWords.TryGetValue(item, out Word_tbl wordFromDic);
                    if (isExsist && probability_mat[wordFromDic.ID_word - 1, category_id] != 0)
                    {
                        prob += probability_mat[wordFromDic.ID_word - 1, category_id];
                        count++;
                        if (!req_Analysis.SimiliarwordsExsistDB.Contains(wordFromDic))  //כי יש מצב שהכניס כבר בעבור קטגוריה אחרת
                            req_Analysis.SimiliarwordsExsistDB.Add(wordFromDic);
                    }
                }
            }
            if (count == 0)
                return 0;
            return prob / count;
        }


        /// <summary>
        /// The function calculates the total general probability for the email request for each category.
        /// </summary>
        /// <returns>Returns an array that contains for each category the final probability of the email request to belong to it.</returns>
        public double[] TotalProbability()
        {
            double[] totalProbability = new double[firstInit_arr.Length];
            int realSizeBodySentences = AmountOfRealSizeSentencesInBody();
            float percentsForSubject = 0, percentsEachSentence = 0;
            PercentageOfSubjectAndBody(realSizeBodySentences, ref percentsForSubject, ref percentsEachSentence);
            for (int i = 0; i < totalProbability.Length; i++)
            {
                foreach (var sentence in req_Analysis.Body)
                {
                    if (sentence.NormalizedBodyWords.Count() != 0) //בעבור משפטים שנוטרלו בשלמותם
                        totalProbability[i] += sentence.ProbabilitybSentenceForCategory[i] * percentsEachSentence;
                }
                totalProbability[i] += req_Analysis.Subject.ProbabilitybSubjectForCategory[i] * percentsForSubject;
                if (req_Analysis.IsContainCategoryManagerID[i])
                {
                    totalProbability[i] *= (float)PercentCalcProb.EmailContent / (int)PercentCalcProb.Hundred;
                    totalProbability[i] += (float)PercentCalcProb.NameOfCategoryManager / (int)PercentCalcProb.Hundred;
                }
            }
            return totalProbability;
        }


        /// <summary>
        /// The function counts how many (non-empty) sentences have content in the body of the email.
        /// </summary>
        /// <returns>The number of sentences with content (non-empty) in the body of the email.</returns>
        public int AmountOfRealSizeSentencesInBody()
        {
            int count = 0;
            foreach (var sentence in req_Analysis.Body)
            {
                if (sentence.NormalizedBodyWords.Count() != 0) //בעבור משפטים שנוטרלו בשלמותם
                    count++;
            }
            return count;
        }


        /// <summary>
        /// The function calculates in relation to the number of sentences in the body of the e-mail
        /// the weight that the subject will receive and each sentence from the e-mail
        /// out of the total probable probability of email request to each category.
        /// The subject of the email is given twice the weight of each sentence in the body of the email.
        /// </summary>
        /// <param name="realSizeBodySentences">A number of sentences with content in the body of the email</param>
        /// <param name="percentsForSubject">The weight given to the subject of the email out of the complete probability</param>
        /// <param name="percentsEachSentence">The weight given to each sentence from the body of the email out of the complete probability</param>
        public void PercentageOfSubjectAndBody(int realSizeBodySentences, ref float percentsForSubject, ref float percentsEachSentence)
        {
            if (realSizeBodySentences == 0)
                percentsForSubject = (float)PercentCalcProb.MaxProbability;
            else
            {
                if (req_Analysis.Subject.NormalizedSubjectWords.Count() == 0)
                    percentsEachSentence = (float)PercentCalcProb.MaxProbability / realSizeBodySentences;
                else
                {
                    percentsEachSentence = (float)PercentCalcProb.MaxProbability / realSizeBodySentences + (int)PercentCalcProb.Subject_VS_Body;
                    percentsForSubject = percentsEachSentence * (int)PercentCalcProb.Subject_VS_Body;
                }
            }
        }


        /// <summary>
        /// The function returns the index of the category with the highest probability.
        /// </summary>
        /// <param name="probability_arr">An array of probabilities for each category.</param>
        /// <returns>index of the category with the highest probability.</returns>
        public int IndexMaxProbability(double[] probability_arr)
        {
            double maxValue = probability_arr.Max();
            for (int i = 0; i < probability_arr.Length; i++)
                if (probability_arr[i] == maxValue)
                    return i;
            return 0;
        }


        /// <summary>
        /// The function calls the functions of Conclusion class,
        /// in order to enter into the DB the data of the current email request for system improvement from now on.
        /// </summary>
        /// <param name="isAutomat">True: if it's automatic sending.  else - false.</param>
        public void InsertConclusionToDB(bool isAutomat)
        {
            Conclusion conclusion = new Conclusion(req_Analysis, request, isAutomat);
            conclusion.AddEmailRequest_tbl(request);
            conclusion.LearningForNext();
            conclusion.AddSendingHistory_tbl(Conclusion.notFromCategory);
        }


        /// <summary>
        /// The function receives an email request manually for a specific category, which allows the system to practice data (tagging).
        /// </summary>
        /// <param name="subject">subject of an email request</param>
        /// <param name="body">body of an email request</param>
        /// <param name="categoryID">ID of the category</param>
        public void InsertRequestToSystem(string subject, string body, int categoryID)
        {
            //להפוך את כל השדות הללו ל- לא שדות חובה
            // SenderEmail = sender, Date = date, EntryId = entryId
            request = new EmailRequest_tbl { EmailSubject = subject, EmailContent = body };
            EmailRequestAnalysis();
            request.ID_category = categoryID;
            InsertConclusionToDB(false);
        }

    }
}
