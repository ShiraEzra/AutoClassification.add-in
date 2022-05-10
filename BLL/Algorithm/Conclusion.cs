using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BLL
{
    public enum StatusKind : byte { FirstLearning = 1, AutomatSend = 2, MenuallSent = 3 }
    public class Conclusion
    {
        static AutomaticClassificationDBEntities db = AutomaticClassificationDBEntities.Instance;

        EmailRequest_tbl request;
        RequestAnalysis reqAnalysis;
        List<WordPerRequest_tbl> requestWord_lst;
        bool isFirstOrAutomat;  //If true: AutomatSend, else:FirstLearning;
        public static int notFromCategory = -1;


        /// <summary>
        /// Constractor triggered from class Algorithm.
        /// </summary>
        /// <param name="analysis">RequestAnalysis</param>
        /// <param name="req">EmailRequest_tbl</param>
        public Conclusion(RequestAnalysis analysis, EmailRequest_tbl req, bool FirstOrAutomat)
        {
            reqAnalysis = analysis;
            request = req;
            isFirstOrAutomat = FirstOrAutomat;
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
            SavingConclusionsInDB(reqAnalysis.Subject.NormalizedSubjectWords);
            List<string> bodyWords = new List<string>();
            foreach (var item in reqAnalysis.Body)
                bodyWords.AddRange(item.NormalizedBodyWords);
            SavingConclusionsInDB(bodyWords);
            IncreasePercentageMatchingForSimWords(reqAnalysis.SimiliarwordsExsistDB);
        }


        /// <summary>
        /// Go over the list words, If the word does not exist at all in DB we will add the word to DB to the word table.
        /// If the word is not yet associated with this category we will add an entry of the word association to the category.
        /// We will increase the matching percentage of the word to a category, and add entry to WordPerRequest table.
        /// </summary>
        /// <param name="words_lst">List of words</param>
        public void SavingConclusionsInDB(List<string> words_lst)
        {
            WordPerCategory_tbl wordPerCategory = null;
            Word_tbl word = null;
            bool isExsist;
            foreach (var w in words_lst)
            {
                isExsist = NaiveBaiseAlgorithm.allWords.TryGetValue(w, out word);
                if (!isExsist)
                {
                    word = AddWord_tbl(w);
                    NaiveBaiseAlgorithm.allWords.Add(word.Value_word, word);
                }
                wordPerCategory = db.WordPerCategory_tbl.Where(wpc => wpc.ID_word == word.ID_word && wpc.ID_category == request.ID_category).FirstOrDefault();
                if (wordPerCategory == null)
                    wordPerCategory = AddWordPerCategory_tbl(word, (int)request.ID_category);
                IncreasePercentageMatching(wordPerCategory, false);
                AddWordPerRequest(request.ID_emailRequest, word.ID_word, false);
            }
        }


        /// <summary>
        /// The function goes through all the email request words and increases the percentage of matching to the category to which the email request was transferred.
        /// </summary>
        public void SavingConclusionsInDB()
        {
            WordPerCategory_tbl wordPerCategory = null;
            Word_tbl word = null;
            foreach (var wpr in requestWord_lst)
            {
                word = wpr.Word_tbl;
                wordPerCategory = db.WordPerCategory_tbl.Where(wpc => wpc.ID_word == wpr.Word_id && wpc.ID_category == request.ID_category).FirstOrDefault();
                if (wordPerCategory == null)
                    wordPerCategory = AddWordPerCategory_tbl(word, (int)request.ID_category);
                if (wpr.IsSimilarWord)
                    IncreasePercentageMatching(wordPerCategory, true);
                else
                    IncreasePercentageMatching(wordPerCategory, false);
            }
        }


        /// <summary>
        /// The function receives a list of similar words (for words from the email request) that exist in the DB.
        ///The function goes through the list, and every word that exists in DB in this category, we add 0.3 percent probability to it.
        /// </summary>
        /// <param name="simWords">List of similar words</param>
        public void IncreasePercentageMatchingForSimWords(List<Word_tbl> simWords)
        {
            WordPerCategory_tbl wordPerCategory = null;
            foreach (var w in simWords)
            {
                wordPerCategory = db.WordPerCategory_tbl.Where(wpc => wpc.ID_word == w.ID_word && wpc.ID_category == request.ID_category).FirstOrDefault();
                if (wordPerCategory != null)
                {
                    IncreasePercentageMatching(wordPerCategory, true);
                    AddWordPerRequest(request.ID_emailRequest, w.ID_word, true);
                }
            }
        }


        /// <summary>
        /// The function increases the percentage of fit of the word to the category.
        /// if it a similar word - add only 0.3 to the amount of use (instead of 1 -in case of word from the email request).
        /// </summary>
        /// <param name="wpc">instance of table wordPerCategory</param>
        public void IncreasePercentageMatching(WordPerCategory_tbl wpc, bool isSimilarWord)
        {
            if (isSimilarWord)
                wpc.AmountOfUse += 0.3f;
            else
                wpc.AmountOfUse += 1;
            db.SaveChanges();
        }


        /// <summary>
        /// Add instance to word_tbl
        /// </summary>
        /// <param name="w">word  (value = string)</param>
        /// <returns>The word added to DB</returns>
        public Word_tbl AddWord_tbl(string w)
        {
            Word_tbl word = new Word_tbl { Value_word = w };
            try
            {
                db.Word_tbl.Add(word);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error in adding item to Word_tbl" + ex.Message);
            }
            return word;
        }


        /// <summary>
        /// Add instance to wordPerCategory_tbl.
        /// </summary>
        /// <param name="word">word -instance of word_tbl</param>
        /// <param name="category_id">category id</param>
        /// <returns>The WordPerCategory added to DB</returns>
        public WordPerCategory_tbl AddWordPerCategory_tbl(Word_tbl word, int category_id)
        {
            WordPerCategory_tbl wordPerCategory = new WordPerCategory_tbl() { ID_word = word.ID_word, ID_category = category_id, AmountOfUse = 0 };
            try
            {
                db.WordPerCategory_tbl.Add(wordPerCategory);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error in adding item to WordPerCategory_tbl" + ex.Message);
            }
            return wordPerCategory;
        }


        /// <summary>
        /// Add an instance to EmailRequest_tbl.
        /// </summary>
        /// <param name="req">The EmailRequest added to DB</param>
        public void AddEmailRequest_tbl(EmailRequest_tbl req)
        {
            try
            {
                db.EmailRequest_tbl.Add(req);
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("error in updating EmailRequest_tbl table");
            }
        }


        /// <summary>
        /// The function adds an entry to  WordPerRequest table.
        /// </summary>
        /// <param name="request_id">reqest id</param>
        /// <param name="word_id">word id</param>
        public void AddWordPerRequest(int request_id, int word_id, bool isSimilsrWords)
        {
            try
            {
                WordPerRequest_tbl wpr = new WordPerRequest_tbl() { Request_id = request_id, Word_id = word_id, IsSimilarWord = isSimilsrWords };
                db.WordPerRequest_tbl.Add(wpr);
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("error in updating AddWordPerRequest table");
            }
        }


        /// <summary>
        /// Add an instance to SendingHistory_tbl.
        /// </summary>
        /// <param name="sentFrom">first time classified = -1. Otherwise -  id of the category to which it belonged the previous time.</param>
        public void AddSendingHistory_tbl(int sentFrom)
        {
            SendingHistory_tbl history;
            if (sentFrom == notFromCategory)
            {
                int statusSending_id = (int)(isFirstOrAutomat ? StatusKind.AutomatSend : StatusKind.FirstLearning);
                history = new SendingHistory_tbl { ID_category = (int)request.ID_category, ID_emailRequest = request.ID_emailRequest, Date = DateTime.Now, ID_StatusSending = statusSending_id };
            }
            else
                history = new SendingHistory_tbl { ID_category = (int)request.ID_category, ID_emailRequest = request.ID_emailRequest, Date = DateTime.Now, ID_StatusSending = (int)StatusKind.MenuallSent, SentFrom = sentFrom };
            db.SendingHistory_tbl.Add(history);
            db.SaveChanges();
        }
    }
}
