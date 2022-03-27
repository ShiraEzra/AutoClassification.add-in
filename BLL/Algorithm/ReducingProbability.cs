using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReducingProbability
    {
        static AutomaticClassificationDBEntities db = AutomaticClassificationDBEntities.Instance;


        /// <summary>
        /// A function that receives a request and a category.
        /// The function associates the email request with this category, and cancels the previous email request association.
        /// </summary>
        /// <param name="req">The email request that changes its fit to the category</param>
        /// <param name="newFolder">The new category to which the email request was referenced</param>
        public static void ChangeCategory(int reqID, string newFolder)
        {
            EmailRequest_tbl req = db.EmailRequest_tbl.Single(e => e.ID_emailRequest == reqID);
            int sentFrom = (int)req.ID_category;
            req.ID_category = db.Category_tbl.Single(c => c.Name_category == newFolder).ID_category;
            List<WordPerRequest_tbl> requestWords = db.WordPerRequest_tbl.Where(w => w.Request_id == req.ID_emailRequest).ToList();
            ReduceProbability(sentFrom, requestWords);

            Conclusion conclusion = new Conclusion(req, requestWords);
            conclusion.SavingConclusionsInDB();
            conclusion.AddSendingHistory_tbl(sentFrom);
        }


        /// <summary>
        /// A function that goes over the list of email request words and lowers the percentage of matches for that email request following the cancellation of the match.
        /// </summary>
        /// <param name="req">The email request that changes its fit to the category</param>
        public static void ReduceProbability(int oldCategoryId, List<WordPerRequest_tbl> requestWords)
        {
            WordPerCategory_tbl wpc;
            foreach (var wpr in requestWords)
            {
                wpc = db.WordPerCategory_tbl.Single(w => w.ID_category == oldCategoryId && w.ID_word == wpr.Word_id);
                if (wpr.IsSimilarWord)   
                    wpc.AmountOfUse -= 0.3f;
                else
                    wpc.AmountOfUse--;
                if (wpc.AmountOfUse == 0)
                    db.WordPerCategory_tbl.Remove(wpc);
                db.SaveChanges();
            }
        }
    }
}
