using BLL.DTO;
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

        //public int GetIdEmailRequestByConversationID(string conversationID)
        //{
        //    EmailRequest_tbl req = db.EmailRequest_tbl.FirstOrDefault(e => e.EntryId == conversationID);
        //    if (req == null)
        //        return -1;
        //    return req.ID_emailRequest;
        //}

        //public string GetCategoryNameOfEmailRequest(int reqID)
        //{
        //    if (reqID != -1)
        //    {
        //        return db.EmailRequest_tbl.Single(e => e.ID_emailRequest == reqID).Category_tbl.Name_category;
        //    }
        //    return null;
        //}


      
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


        /// <summary>
        /// The function return a list with all names of the categories
        /// </summary>
        /// <returns>a list of string</returns>
        public List<string> GetAllCategoriesNames()
        {
            return db.Category_tbl.Select(c => c.Name_category).ToList();
        }

        public bool IsExsistCategories()
        {
            return db.Category_tbl.Count() > 0;
        }

        /// <summary>
        /// The function return a list of all the categories
        /// </summary>
        /// <returns>a listo of categories</returns>
        public List<Category> GetAllCategories()
        {
            var categoryTbl_lst = db.Category_tbl.ToList();
            List<Category> category_lst = new List<Category>();
            categoryTbl_lst.ForEach(c => category_lst.Add(Category.DalToDto(c)));
            return category_lst;
        }

        public Category GetCategoryByID(int category_ID)
        {
            return Category.DalToDto(db.Category_tbl.FirstOrDefault(c => c.ID_category == category_ID));
        }

        //public List<PermissionLevel> GetAllPL()
        //{
        //    var plTbl_lst = db.PermissionLevel_tbl.ToList();
        //    List<PermissionLevel> pl_lst = new List<PermissionLevel>();
        //    plTbl_lst.ForEach(p => pl_lst.Add(PermissionLevel.DalToDto(p)));
        //    return pl_lst;
        //}

        public Manager_tbl GetManagerByPassword(string password)
        {
            return db.Manager_tbl.FirstOrDefault(m => m.Password == password);
        }

        public List<User> GetAllUsers()
        {
            //var userTbl_lst = db.User_tbl.ToList();
            //User[] user_arr = new User[userTbl_lst.Count];
            //int i = 0;
            //foreach (var user_tbl in userTbl_lst)
            //    user_arr[i++] = User.DalToDto(user_tbl);
            //return user_arr;

            var userTbl_lst = db.User_tbl.ToList();
            List<User> user_lst = new List<User>();
            userTbl_lst.ForEach(u => user_lst.Add(User.DalToDto(u)));
            return user_lst;
        }
    }
}
