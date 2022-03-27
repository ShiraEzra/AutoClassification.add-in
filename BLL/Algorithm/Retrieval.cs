using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Retrieval
    {
        //להוסיף תיעוד אקסמלי
        AutomaticClassificationDBEntities db = AutomaticClassificationDBEntities.Instance;

        public int GetIdEmailRequestByConversationID(string conversationID)
        {
            EmailRequest_tbl req = db.EmailRequest_tbl.FirstOrDefault(e => e.EntryId == conversationID);
            if (req == null)
                return -1;
            return req.ID_emailRequest;
        }

        public string GetCategoryNameOfEmailRequest(int reqID)
        {
            if (reqID != -1)
            {
                return db.EmailRequest_tbl.Single(e => e.ID_emailRequest == reqID).Category_tbl.Name_category;
            }
            return null;
        }

        public List<string> GetAllCategoriesNames()
        {
            return db.Category_tbl.Select(c => c.Name_category).ToList();
        }


        /// <summary>
        /// Function that removes irrelevant things from the body of the email.
        /// </summary>
        /// <param name="body">The body of the email</param>
        /// <returns>Relevant email body only</returns>
        public string RelevantBodyOnly(string body)
        {
            int start, end;
            while (body.Contains("---------- Forwarded message ---------"))
            {
                start = body.IndexOf("---------- Forwarded message ---------");
                end = body.IndexOf("To:");
                end = body.IndexOf(">", end + 1);
                end = body.IndexOf(">", end + 1);
                body = body.Substring(0, start - 1) + " " + body.Substring(end + 1);
            }
            while (body.Contains("<https"))
            {
                start = body.IndexOf("<https");
                end = body.IndexOf('>', start);
                body = body.Substring(0, start - 1) + " " + body.Substring(end + 1);
            }
            while (body.Contains("<data:image"))
            {
                start = body.IndexOf("<data:image");
                end = body.IndexOf('>', start);
                body = body.Substring(0, start - 1) + " " + body.Substring(end + 1);
            }
            if (body.Contains("Sender notified by"))
            {
                start = body.IndexOf("Sender notified by");
                body = body.Substring(0, start);
            }
            return body;
        }


        public void GetManager(string password, out int managerCode, out int permissionLevel, out string managerName, out int id_category, out string id_user)
        {
            User_tbl user = db.User_tbl.FirstOrDefault(u => u.Password == password);
            if (user != null)
            {
                managerCode = user.Code;
                permissionLevel = user.ID_premissionLevel;
                managerName = user.Name_user;
                id_category = user.ID_category==null? -1 :(int)user.ID_category;
                id_user = user.ID_user;
            }
            else
            {
                managerCode = -1;
                permissionLevel = -1;
                managerName = null;
                id_category = -1;
                id_user = null;
            }
        }

        //public void GetManagerNameAndPL(int managerCode, out int permissionLevel, out string managerName)
        //{
        //    User_tbl user = db.User_tbl.FirstOrDefault(u => u.Code == managerCode);
        //    permissionLevel = user.ID_premissionLevel;
        //    managerName = user.Name_user;

        //}
    }
}
