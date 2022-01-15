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
        public static void ChangeCategory(EmailRequest_tbl req, string newFolder)
        {
            ReduceProbability(req);
            int newCategoryId=db.Category_tbl.Single(c => c.Name_category == newFolder).ID_category;
            int sentFrom = (int)req.ID_category;
            req.ID_category = newCategoryId;

            //צריך לשלוח לבינה זו עצם מסוג ריקווסט-אניליסיס
            //לשאול את המורה איך אני שומרת את מילות הפנייה המנותחת בעבור כל פנייה. ע"מ שבת שינוי קטגוריה אני אוכל לעבור עליהם ולשנות
            
            //Conclusion conclusion = new Conclusion();
            //conclusion.LearningForNext();
            //conclusion.AddSendingHistory_tbl(sentFrom);
        }


        /// <summary>
        /// A function that goes over the list of email request words and lowers the percentage of matches for that email request following the cancellation of the match.
        /// </summary>
        /// <param name="req">The email request that changes its fit to the category</param>
        public static void ReduceProbability(EmailRequest_tbl req)
        {
            //לברר איך בדיוק אני שומרת את מילות הפנייה המנותחות
        }
    }
}
