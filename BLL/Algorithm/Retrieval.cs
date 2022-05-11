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
        static AutomaticClassificationDBEntities db = AutomaticClassificationDBEntities.Instance;


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


        /// <summary>
        /// The function checks if there is any category in DB
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// The function returns the category of its received code.
        /// </summary>
        /// <param name="category_ID">category id</param>
        /// <returns>Category with the code obtained</returns>
        public Category GetCategoryByID(int category_ID)
        {
            return Category.DalToDto(db.Category_tbl.FirstOrDefault(c => c.ID_category == category_ID));
        }


        /// <summary>
        /// A static method that returns a dal category with the resulting code.
        /// </summary>
        /// <param name="category_ID"></param>
        /// <returns>Dal category with the resulting code</returns>
        public static Category_tbl GetCategory_tblByID(int category_ID)
        {
            return db.Category_tbl.FirstOrDefault(c => c.ID_category == category_ID);
        }


        /// <summary>
        ///The function returns the administrator with the resulting password.
        /// </summary>
        /// <param name="password">a password</param>
        /// <returns>manager with ths password</returns>
        public Manager_tbl GetManagerByPassword(string password)
        {
            return db.Manager_tbl.FirstOrDefault(m => m.Password == password);
        }


        /// <summary>
        /// The function returns the list of department heads in the system.
        /// </summary>
        /// <returns>list of User</returns>
        public List<User> GetAllUsers()
        {
            var userTbl_lst = db.User_tbl.ToList();
            List<User> user_lst = new List<User>();
            userTbl_lst.ForEach(u => user_lst.Add(User.DalToDto(u)));
            return user_lst;
        }
    }
}
