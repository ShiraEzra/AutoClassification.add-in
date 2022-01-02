﻿using DAL;
using DTO;
using HebrewNLP.Morphology;
using HebrewNLP.Names;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Algorithm
    {
        AutoClassificationDBEntities db = AutoClassificationDBEntities.Instance;
        const int numOfSimiliarWords = 10;

        float[,] probability_mat;   //A matrix that contains in each cell the probability of a word to belong to a specific category.
        float[] firstInit_arr;      //An initialized array with the number of email requests for each category.
        RequestAnalysis req_Analysis;    //Object containing the request analysis.
        Dictionary<string, Word_tbl> allWords;   //All words from word_tbl as dictionary.

        public Algorithm()
        {
            probability_mat = new float[db.Word_tbl.Count(), db.Category_tbl.Count()];
            req_Analysis = new RequestAnalysis();
            allWords = GetAllWordsAsDictionary();
            firstInit_arr = FirstInitProbability_arr();
            BuildProbabilityMat();
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
            float[] totalProbability = TotalProbability();
            return IndexMaxProbability(totalProbability);  //צריך להחזיר את הקטגוריה
        }


        /// <summary>
        /// Analysis of the subject of the email
        /// </summary>
        /// <param name="subject">email subject</param>
        public void SubjetcAnalysis(string subject)
        {
            List<List<MorphInfo>> analyzedSubject = AnalyzeSentence(subject);
            req_Analysis.NormalizedSubjectWords = RemoveIrrelevantWords(analyzedSubject);
            req_Analysis.ProbabilitybSubjectForCategory = CalcProbabilityForCategory(req_Analysis.NormalizedSubjectWords, req_Analysis.ProbabilitybSubjectForCategory);
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
                req_Analysis.bodyAnalysis[i].ProbabilitybSentenceForCategory = CalcProbabilityForCategory(req_Analysis.bodyAnalysis[i].NormalizedBodyWords, req_Analysis.bodyAnalysis[i].ProbabilitybSentenceForCategory);
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
                    rellevantWords.Add(firstword.BaseWordMenukad == null ? firstword.BaseWord : firstword.BaseWordMenukad);
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
            return morphInfo.PartOfSpeech == PartOfSpeech.VERB || morphInfo.PartOfSpeech == PartOfSpeech.NOUN || morphInfo.PartOfSpeech == PartOfSpeech.ADJECTIVE || morphInfo.PartOfSpeech == PartOfSpeech.PROPER_NOUN;
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
        /// The function analyzes the words.
        /// </summary>
        /// <param name="words"> list of words</param>
        /// <returns>analyzed words</returns>
        public List<List<MorphInfo>> AnalyzeWords(string[] words)
        {
            HebrewNLP.HebrewNLP.Password = "3BGkxLKouDk3l7B";
            return HebrewMorphology.AnalyzeWords(words);
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
        /// The function calculates for each category the probability of the sentence to belong to it.
        /// </summary>
        /// <param name="contentWords_lst">A list of strings containing the sentence.</param>
        /// <returns>An array that contains for each category its probability of belonging to this a category.</returns>
        public float[] CalcProbabilityForCategory(List<string> contentWords_lst, float[] categoryProbability_arr)
        {
            Word_tbl word;
            float prob_similiarWords = 0, prob = 0;
            //בעבור כל מילה הקיימת בדטה בייס - מחשבים את ההסתברות שלה + ההסתברות של המלילם הדומות לה הקיימות ב-דטה בייס
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
                    prob = prob * 0.6f + prob_similiarWords * 0.4f;   //משקל של 60% להסתברות של המילה עצמה, ו-40% להסתברות של המילים הדומות.
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
            probability_arr = new float[firstInit_arr.Length] ;
            if (flag)
                firstInit_arr.CopyTo(probability_arr, 0);
            else    //לבדוק אם באמת צריך לאפס
                for (int i = 0; i < probability_arr.Length; i++)
                    probability_arr[i] = 0;
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


        /// <summary>
        /// Calculating the probability of words similar to the word.
        /// </summary>
        /// <param name="word">word</param>
        /// <param name="category_id">category id</param>
        /// <returns>the probability of words similar to the word</returns>
        public float SimiliarWords_probability(string word, int category_id)
        {
            //על המילים הדומות שמקבלים צריך לבדוק שוב האם קיימות ב-דטה בייס לקטגוריה זו, ולהחזיר את ההסתברות, אם לא קיימות  להחזיר 0
            List<string> similarWords = GetSimilarWords(word);
            List<List<MorphInfo>> analyzedWords = AnalyzeWords(similarWords.ToArray());
            List<string> normalizedSimWords = RemoveIrrelevantWords(analyzedWords);
            float prob = 0;
            int count = 0;
            Word_tbl wordFromDic = null;
            foreach (var item in normalizedSimWords)
            {
                bool isExsist = allWords.TryGetValue(item, out wordFromDic);
                if (isExsist && probability_mat[wordFromDic.ID_word - 1, category_id] != 0)
                {

                    prob += probability_mat[wordFromDic.ID_word - 1, category_id];
                    count++;
                }
            }
            return prob / count;
        }


        /// <summary>
        /// Extract similar words from the Html code.
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>list of similiar words</returns>
        public List<string> GetSimilarWords(string word)
        {
            string html_ans = GetDataFromSimilarWordsSite(word);
            if (html_ans.Contains("<h1>האם התכוונת ל-</h1>"))
                return null;
            List<string> similarWords = new List<string>();
            int start = html_ans.IndexOf("data-word");
            html_ans = html_ans.Substring(start);
            start = 0;
            int end;
            while (similarWords.Count() <= 10 && start != -1)
            {
                start = html_ans.IndexOf("\"", start) + 1;
                end = html_ans.IndexOf("\"", start);
                string sim_word = html_ans.Substring(start, end - start);
                similarWords.Add(sim_word);
                start = html_ans.IndexOf("data-word", end);
            }
            similarWords.RemoveAt(0);  //הראשון זה המילה בעצמה
            return similarWords;
        }


        /// <summary>
        /// Gets html code with the similiar words to the word wich sent.
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>html code as string</returns>
        public string GetDataFromSimilarWordsSite(string word)
        {
            string html_ans;
            using (WebClient client = new WebClient())
            {
                var data = client.DownloadData("https://synonyms.reverso.net/%D7%9E%D7%9C%D7%99%D7%9D-%D7%A0%D7%A8%D7%93%D7%A4%D7%95%D7%AA/he/" + word);
                html_ans = Encoding.UTF8.GetString(data);
            }
            return html_ans;
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
                foreach (var sentence in req_Analysis.bodyAnalysis)
                    totalProbability[i] += sentence.ProbabilitybSentenceForCategory[i];
                totalProbability[i] /= req_Analysis.bodyAnalysis.Count();
                //חיבור ההסתברות של גוף המייל עם הנושא
                totalProbability[i] += req_Analysis.ProbabilitybSubjectForCategory[i];
                totalProbability[i] /= 2;
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
            //לראות אולי צאיך לבצע בדיקה יותר חחכמה מחיפוש שרירותי אחר המקסימום
            //אם יש כמה קטגוריות שקרובות למקס, צריך לבצע בדיקות נוספות לדוגמא: אנשי קשר

            float maxValue = probability_arr.Max();
            for (int i = 0; i < probability_arr.Length; i++)
                if (probability_arr[i] == maxValue)
                    return i;
            return 0;
        }
    }
}
