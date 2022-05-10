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
        public static int numSucceeded = 0, numTryings = 0;
        public static float totalPrecision;

        public float LearningFolderRequests(List<EmailRequest> folderEmailRequests, string nameFolder)
        {
            int categoryID = AddCategory(nameFolder);
            int i = 0, numFolderRequests = folderEmailRequests.Count(), numSucceededAssociations = 0;
            int learningEightyPercents = (int)Math.Round(numFolderRequests / (double)((int)PercentPrecision.Hundred * (int)PercentPrecision.Eighty));
            int tryingTwentyPercents = numFolderRequests - learningEightyPercents;
            foreach (var req in folderEmailRequests)
            {
                NaiveBaiseAlgorithm algorithm = new NaiveBaiseAlgorithm();
                EmailRequest_tbl request = new EmailRequest_tbl() { EmailSubject = req.Subject, EmailContent = req.Body, SenderEmail = req.Sender, Date = req.Date, EntryId = req.EntryID };
                request.ID_category = categoryID;
                if (i++ < learningEightyPercents)   //למידה פשוטה
                    LearningInsertion(algorithm, request);
                else   //נסוי סיווג - ובדיקת אחוזי דיוק
                {
                    if (TryingInsertion(algorithm, request, categoryID))
                        numSucceededAssociations++;
                }
            }
            UpdateTotalPrecision(numSucceededAssociations, tryingTwentyPercents);
            float precision = numSucceededAssociations/tryingTwentyPercents * 100;
            return precision; 
        }

        public int AddCategory(string nameCategory)
        {
            Category_tbl category = new Category_tbl() { Name_category = nameCategory };
            db.Category_tbl.Add(category);
            db.SaveChanges();
            return db.Category_tbl.Single(c => c.Name_category == nameCategory).ID_category;
        }

        public void LearningInsertion(NaiveBaiseAlgorithm algorithm, EmailRequest_tbl request)
        {
            algorithm.AnalyzeRequest(request);
            algorithm.InsertConclusionToDB(false);
        }

        public bool TryingInsertion(NaiveBaiseAlgorithm algorithm, EmailRequest_tbl request, int categoryID)
        {
            algorithm.AnalyzeAndAssociateRequest(request);
            if (request.ID_category == categoryID)
                return true;
            return false;
        }

        public void UpdateTotalPrecision(int numSucceededAssociations, int tryingTwentyPercents)
        {
            numSucceeded += numSucceededAssociations;
            numTryings += tryingTwentyPercents;
            totalPrecision = numSucceeded / numTryings * 100;
        }
    }
}
