using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public enum StatusKind :byte{ FirstLearning=1, AutomatSend=2, MenuallSent=3}
    public class Conclusion
    {
        AutomaticClassificationDBEntities db = AutomaticClassificationDBEntities.Instance;

        EmailRequest_tbl request;
        RequestAnalysis reqAnalysis;
        List<WordPerRequest_tbl> requestWord_lst;
        bool IsFirstOrAutomat;  //If true: AutomatSend, else:FirstLearning;

        /// <summary>
        /// Constractor triggered from class Algorithm.
        /// </summary>
        /// <param name="analysis">RequestAnalysis</param>
        /// <param name="req">EmailRequest_tbl</param>
        public Conclusion(RequestAnalysis analysis, EmailRequest_tbl req, bool FirstOrAutomat)
        {
            reqAnalysis = analysis;
            request = req;
            IsFirstOrAutomat = FirstOrAutomat;
        }


        /// <summary>
        /// Constractor triggered from class ReducingProbability.
        /// </summary>
        /// <param name="req">EmailRequest_tbl</param>
        /// <param name="wordsPerRequest">List of WordPerRequest_tbl</param>
        public Conclusion(EmailRequest_tbl req, List<WordPerRequest_tbl> wordsPerRequest)
        {
            request = req;
            requestWord_lst = wordsPerRequest;
        }


        /// <summary>
        /// Go over each part of the email request analysis (subject / body) and sending to the SavingConclusionsInDB function.
        /// </summary>
        /// <param name="category_id">The number of the category to which the email request belongs</param>
        public void LearningForNext()
        {
            SavingConclusionsInDB(reqAnalysis.NormalizedSubjectWords);
            List<string> bodyWords = new List<string>();
            foreach (var item in reqAnalysis.BodyAnalysis)
                bodyWords.AddRange(item.NormalizedBodyWords);
            SavingConclusionsInDB(bodyWords);
            SavingSimiliarwordsForRequest(reqAnalysis.SimiliarwordsExsistDB);
        }


        /// <summary>
        /// Go over the list words, If the word does not exist at all in DB we will add the word to DB to the word table.
        /// If the word is not yet associated with this category we will add an entry of the word association to the category.
        /// We will increase the matching percentage of the word to a category.
        /// </summary>
        /// <param name="words_lst">List of words</param>
        public void SavingConclusionsInDB(List<string> words_lst)
        {
            WordPerCategory_tbl wordPerCategory = null;
            Word_tbl word = null;
            bool isExsist;
            int numRequestsForThisCategory = db.EmailRequest_tbl.Where(er => er.ID_category == request.ID_category).Count();
            foreach (var w in words_lst)
            {
                isExsist = NaiveBaiseAlgorithm.allWords.TryGetValue(w, out word);
                if (!isExsist)
                    word = AddWord_tbl(w);
                wordPerCategory = db.WordPerCategory_tbl.Where(wpc => wpc.ID_word == word.ID_word && wpc.ID_category == request.ID_category).FirstOrDefault();
                if (wordPerCategory == null)
                    wordPerCategory = AddWordPerCategory_tbl(word, (int)request.ID_category);
                IncreasePercentageMatching(wordPerCategory, numRequestsForThisCategory);
                AddWordPerRequest(request.ID_emailRequest, word.ID_word);
            }
        }


        /// <summary>
        /// The function goes through all the email request words and increases the percentage of matching to the category to which the email request was transferred.
        /// </summary>
        public void SavingConclusionsInDB()
        {
            int numRequestsForThisCategory = db.EmailRequest_tbl.Where(er => er.ID_category == request.ID_category).Count();
            WordPerCategory_tbl wordPerCategory = null;
            Word_tbl word= null;
            foreach (var wpr in requestWord_lst)
            {
                word = wpr.Word_tbl;
                wordPerCategory = db.WordPerCategory_tbl.Where(wpc => wpc.ID_word == wpr.word_id && wpc.ID_category == request.ID_category).FirstOrDefault();
                if (wordPerCategory == null)
                    wordPerCategory = AddWordPerCategory_tbl(word, (int)request.ID_category);
                IncreasePercentageMatching(wordPerCategory, numRequestsForThisCategory);
            }
        }


        /// <summary>
        /// The function increases the percentage of fit of the word to the category
        /// </summary>
        /// <param name="wpc">instance of table wordPerCategory</param>
        public void IncreasePercentageMatching(WordPerCategory_tbl wpc, int numRequestsForThisCategory)
        {
            wpc.AmountOfUse++;
            wpc.MatchPercentage = wpc.AmountOfUse / numRequestsForThisCategory;
            db.SaveChanges();
        }


        /// <summary>
        /// The function goes through all the words similar to the words from the email request which existing  in DB,
        /// and adds them to WordPerCategory table
        /// </summary>
        /// <param name="similiarwords">List of similar words</param>
        public void SavingSimiliarwordsForRequest(List<Word_tbl> similiarwords)
        {
            foreach (var simWord in similiarwords)
                AddWordPerRequest(request.ID_emailRequest, simWord.ID_word);
            //צריך להוסיף גם למילים הדומות את אחוזי ההתאמה??
        }


        /// <summary>
        /// Add instance to word_tbl
        /// </summary>
        /// <param name="w">word  (value = string)</param>
        /// <returns></returns>
        public Word_tbl AddWord_tbl(string w)
        {
            Word_tbl word = new Word_tbl { Value_word = w };
            db.Word_tbl.Add(word);
            db.SaveChanges();
            return word;
        }


        /// <summary>
        /// Add instance to wordPerCategory_tbl
        /// </summary>
        /// <param name="word">word -instance of word_tbl</param>
        /// <param name="category_id">category id</param>
        /// <returns></returns>
        public WordPerCategory_tbl AddWordPerCategory_tbl(Word_tbl word, int category_id)
        {
            WordPerCategory_tbl wordPerCategory = new WordPerCategory_tbl
            {
                ID_word = word.ID_word,
                ID_category = category_id,
                AmountOfUse = 0,   //צריך לאתחל?
                MatchPercentage = 0   //צריך לאתחל?
            };
            db.WordPerCategory_tbl.Add(wordPerCategory);
            db.SaveChanges();
            return wordPerCategory;
        }


        /// <summary>
        /// Add an instance to emailRequest_tbl
        /// </summary>
        /// <param name="req"></param>
        public void AddEmailRequest_tbl(EmailRequest_tbl req)
        {
            db.EmailRequest_tbl.Add(req);
            db.SaveChanges();
        }


        /// <summary>
        /// Add an instance to SendingHistory_tbl
        /// </summary>
        /// <param name="sentFrom">s first time classified = -1. Otherwise -  id of the category to which it belonged the previous time.</param>
        public void AddSendingHistory_tbl(int sentFrom)
        {
            SendingHistory_tbl history;
            if (sentFrom == -1)
            {
                int statusSending_id = (int)(IsFirstOrAutomat ? StatusKind.AutomatSend : StatusKind.FirstLearning);
                history =new SendingHistory_tbl { ID_category = (int)request.ID_category, ID_emailRequest = request.ID_emailRequest, Date = new DateTime(), ID_StatusSending = statusSending_id };
            }
            else
                history = new SendingHistory_tbl { ID_category = (int)request.ID_category, ID_emailRequest = request.ID_emailRequest, Date = new DateTime(), ID_StatusSending = (int)StatusKind.MenuallSent, SentFrom = sentFrom };
            db.SendingHistory_tbl.Add(history);
            db.SaveChanges();
        }


        /// <summary>
        /// The function adds an entry to  WordPerRequest table.
        /// </summary>
        /// <param name="request_id">reqest id</param>
        /// <param name="word_id">word id</param>
        public void AddWordPerRequest(int request_id, int word_id)
        {
            WordPerRequest_tbl wpr = new WordPerRequest_tbl() { Request_id = request_id, word_id = word_id };
            db.WordPerRequest_tbl.Add(wpr);
            db.SaveChanges();
        }
    }
}
