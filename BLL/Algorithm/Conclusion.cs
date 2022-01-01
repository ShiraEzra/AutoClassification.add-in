using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Conclusion
    {
        AutoClassificationDBEntities db = AutoClassificationDBEntities.Instance;

        RequestAnalysis reqAnalysis;
        public Conclusion(RequestAnalysis request)
        {
            reqAnalysis = request;
        }


        /// <summary>
        /// Go over each part of the email request analysis (subject / body) and sending to the SavingConclusionsInDB function.
        /// </summary>
        /// <param name="category_id">The number of the category to which the email request belongs</param>
        /// <param name="allWordsDic">all Db words as dictionary</param>
        public void LearningForNext(int category_id, Dictionary<string, Word_tbl> allWordsDic)
        {
            SavingConclusionsInDB(reqAnalysis.NormalizedSubjectWords, category_id, allWordsDic);
            List<string> bodyWords = new List<string>();
            foreach (var item in reqAnalysis.bodyAnalysis)
            {
                bodyWords.AddRange(item.NormalizedBodyWords);
            }
            SavingConclusionsInDB(bodyWords, category_id, allWordsDic);
        }


        /// <summary>
        /// Go over the list words, If the word does not exist at all in DB we will add the word to DB to the word table.
        /// If the word is not yet associated with this category we will add an entry of the word association to the category.
        /// We will increase the matching percentage of the word to a category.
        /// </summary>
        /// <param name="words_lst">List of words</param>
        /// <param name="category_id">The number of the category to which the email request belongs</param>
        /// <param name="allWordsDic">all Db words as dictionary</param>

        public void SavingConclusionsInDB(List<string> words_lst, int category_id, Dictionary<string, Word_tbl> allWordsDic)
        {
            WordPerCategory_tbl wordPerCategory = null;
            Word_tbl word = null;
            bool isExsist;
            foreach (var w in words_lst)
            {
                isExsist= allWordsDic.TryGetValue(w, out word);
                if (!isExsist)
                    word = AddWord_tbl(w);
                wordPerCategory = db.WordPerCategory_tbl.Where(wpc => wpc.ID_word == word.ID_word && wpc.ID_category == category_id).FirstOrDefault();
                if (wordPerCategory == null)
                    wordPerCategory = AddWordPerCategory_tbl(word, category_id);
                IncreasePercentageMatching(wordPerCategory);
            }
        }


        /// <summary>
        /// The function increases the percentage of fit of the word to the category
        /// </summary>
        /// <param name="wpc">instance of table wordPerCategory</param>
        public void IncreasePercentageMatching(WordPerCategory_tbl wpc)
        {
            wpc.AmountOfUse++;
            int numRequestsForThisCategory = db.EmailRequest_tbl.Where(er => er.ID_category == wpc.ID_category).Count();
            wpc.MatchPercentage = wpc.AmountOfUse / numRequestsForThisCategory;
            db.SaveChanges();
        }


        /// <summary>
        /// Add instance to word_tbl
        /// </summary>
        /// <param name="w">word  (value = string)</param>
        /// <returns></returns>
        public Word_tbl AddWord_tbl(string w)
        {
            Word_tbl word = new Word_tbl();
            word.Value_word = w;
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
            WordPerCategory_tbl wordPerCategory = new WordPerCategory_tbl();
            wordPerCategory.ID_word = word.ID_word;
            wordPerCategory.ID_category = category_id;
            wordPerCategory.AmountOfUse = 0;   //צריך לאתחל?
            wordPerCategory.MatchPercentage = 0;   //צריך לאתחל?
            db.WordPerCategory_tbl.Add(wordPerCategory);
            db.SaveChanges();
            return wordPerCategory;
        }


        /// <summary>
        /// Add instance to emailRequest_tbl
        /// </summary>
        /// <param name="req"></param>
        public void AddEmailRequest_tbl(EmailRequest_tbl req)
        {
            db.EmailRequest_tbl.Add(req);
            db.SaveChanges();
        }
    }
}
