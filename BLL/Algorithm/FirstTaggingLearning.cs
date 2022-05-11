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


        /// <summary>
        /// The function receives a list of email requests from a folder. The function goes through the email requests,
        /// studies them, and puts its conclusions into DB for the specified category.
        /// </summary>
        /// <param name="folderEmailRequests">The function receives a list of email requests from a folder.</param>
        /// <param name="nameFolder">The name of the directory to which the email requests list belongs.</param>
        /// <returns></returns>
        public float LearningFolderRequests(List<EmailRequest> folderEmailRequests, string nameFolder)
        {
            int categoryID = AddCategory(nameFolder);
            int i = 0, numFolderRequests = folderEmailRequests.Count(), numSucceededAssociations = 0;
            int learningEightyPercents = (int)Math.Round(numFolderRequests / (double)((int)PercentPrecision.Hundred * (int)PercentPrecision.Eighty));
            int tryingTwentyPercents = numFolderRequests - learningEightyPercents;
            foreach (var req in folderEmailRequests)
            {
                NaiveBaiseAlgorithm algorithm = new NaiveBaiseAlgorithm();
                EmailRequest_tbl request = new EmailRequest_tbl()
                {
                    EmailSubject = req.Subject,
                    EmailContent = req.Body,
                    SenderEmail = req.Sender,
                    Date = req.Date,
                    EntryId = req.EntryID
                };
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
            float precision = numSucceededAssociations / tryingTwentyPercents * 100;
            return precision;
        }


        /// <summary>
        /// The function adds a category (folder name) to the list of categories.
        /// </summary>
        /// <param name="nameCategory">A folder name</param>
        /// <returns></returns>
        public int AddCategory(string nameCategory)
        {
            Category_tbl category = new Category_tbl() { Name_category = nameCategory };
            db.Category_tbl.Add(category);
            db.SaveChanges();
            return db.Category_tbl.Single(c => c.Name_category == nameCategory).ID_category;
        }


        /// <summary>
        /// The function receives an email request, studies it and submits its conclusions to DB for this category.
        /// </summary>
        /// <param name="algorithm">instance of NaiveBaiseAlgorithm class</param>
        /// <param name="request">The email request</param>
        public void LearningInsertion(NaiveBaiseAlgorithm algorithm, EmailRequest_tbl request)
        {
            algorithm.AnalyzeRequest(request);
            algorithm.InsertConclusionToDB(false);
        }


        /// <summary>
        /// The function receives an email request, and tries to classify it.
        /// Before entering the DB we will check that indeed the algorithm was able to classify into the correct category.
        /// This way we can estimate the percentage accuracy of the system initially
        /// </summary>
        /// <param name="algorithm">instance of NaiveBaiseAlgorithm class</param>
        /// <param name="request">The email request</param>
        /// <param name="categoryID">The category code to which the reference should be categorized</param>
        /// <returns></returns>
        public bool TryingInsertion(NaiveBaiseAlgorithm algorithm, EmailRequest_tbl request, int categoryID)
        {
            algorithm.AnalyzeAndAssociateRequest(request);
            if (request.ID_category == categoryID)
                return true;
            return false;
        }


        /// <summary>
        /// Once we have learned the references of another folder, we will update the initial accuracy percentages of the system.
        /// </summary>
        /// <param name="numSucceededAssociations">The number of e-mail requests that the algorithm was able to classify correctly (out of 20%)</param>
        /// <param name="tryingTwentyPercents">20% of all email requests from the directory</param>
        public void UpdateTotalPrecision(int numSucceededAssociations, int tryingTwentyPercents)
        {
            numSucceeded += numSucceededAssociations;
            numTryings += tryingTwentyPercents;
            totalPrecision = numSucceeded / numTryings * 100;
        }
    }
}
