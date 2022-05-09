using BLL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    enum PercentPrecision : byte { Eighty = 80, Hundred = 100 };

    public class FirstTaggingLearning
    {
        readonly AutomaticClassificationDBEntities db = AutomaticClassificationDBEntities.Instance;


        public int LearningFolderRequests(List<EmailRequest> folderEmailRequests, string nameFolder)
        {
            //יצירת הקטגוריה
            Category_tbl category = new Category_tbl() { Name_category = nameFolder };
            db.Category_tbl.Add(category);
            db.SaveChanges();
            //מעבר על פניות המייל של קטגוריה זו
            int numRequests = folderEmailRequests.Count();
            int learningEightyPercents = (int)Math.Round(numRequests / (double)((int)PercentPrecision.Hundred * (int)PercentPrecision.Eighty));
            for (int i = 0; i < numRequests; i++)
            {
                NaiveBaiseAlgorithm algorithm = new NaiveBaiseAlgorithm();

                if (i<learningEightyPercents)   //למידה פשוטה
                {


                    Conclusion conclusion = new Conclusion(req, requestWords);
                    conclusion.SavingConclusionsInDB();
                    conclusion.AddSendingHistory_tbl(sentFrom);
                }
                else   //נסוי סיווג - ובדיקת אחוזי דיוק
                {

                }
            }
        }
    }
}
