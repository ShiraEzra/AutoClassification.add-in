using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class DbRetrieval
    {
        AutoClassificationDBEntities db = AutoClassificationDBEntities.Instance;

        //Category
        public RequestResult GetAllCategories()
        {

            List<Category> lst = new List<Category>();
            foreach (var item in db.Category_tbl.ToList())
            {
                lst.Add(Category.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }

        public void AddCategory(Category c)
        {
            db.Category_tbl.Add(c.DtoTODal());
            db.SaveChanges();
        }


        //EmailRequest
        public RequestResult GetAllEmailRequests()
        {

            List<EmailRequest> lst = new List<EmailRequest>();
            foreach (var item in db.EmailRequest_tbl.ToList())
            {
                lst.Add(EmailRequest.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }

        public void AddEmailRequest(EmailRequest e)
        {
            db.EmailRequest_tbl.Add(e.DtoTODal());
            db.SaveChanges();
        }


        //PermissionLevel
        public RequestResult GetAllPermissionLevels()
        {

            List<PermissionLevel> lst = new List<PermissionLevel>();
            foreach (var item in db.PermissionLevel_tbl.ToList())
            {
                lst.Add(PermissionLevel.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }

        public void AddPermissionLevel(PermissionLevel p)
        {
            db.PermissionLevel_tbl.Add(p.DtoTODal());
            db.SaveChanges();
        }


        //SendingAdjustmentStatus
        public RequestResult GetAllSendingAdjustmentsStatus()
        {

            List<SendingAdjustmentStatus> lst = new List<SendingAdjustmentStatus>();
            foreach (var item in db.SendingAdjustmentStatus_tbl.ToList())
            {
                lst.Add(SendingAdjustmentStatus.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }

        public void AddSendingAdjustmentStatus(SendingAdjustmentStatus s)
        {
            db.SendingAdjustmentStatus_tbl.Add(s.DtoTODal());
            db.SaveChanges();
        }


        //SendingHistory
        public RequestResult GetAllSendingsHistory()
        {

            List<SendingHistory> lst = new List<SendingHistory>();
            foreach (var item in db.SendingHistory_tbl.ToList())
            {
                lst.Add(SendingHistory.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }

        public void AddSendingHistory(SendingHistory s)
        {
            db.SendingHistory_tbl.Add(s.DtoTODal());
            db.SaveChanges();
        }


        //User
        public RequestResult GetAllUsers()
        {

            List<User> lst = new List<User>();
            foreach (var item in db.User_tbl.ToList())
            {
                lst.Add(User.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }

        public void AddUser(User u)
        {
            db.User_tbl.Add(u.DtoTODal());
            db.SaveChanges();
        }


        //Word
        public RequestResult GetAllWords()
        {

            List<Word> lst = new List<Word>();
            foreach (var item in db.Word_tbl.ToList())
            {
                lst.Add(Word.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }

        public void AddWord(Word w)
        {
            db.Word_tbl.Add(w.DtoTODal());
            db.SaveChanges();
        }


        //WordPerCategory
        public RequestResult GetAllWordsPerCategory()
        {

            List<WordPerCategory> lst = new List<WordPerCategory>();
            foreach (var item in db.WordPerCategory_tbl.ToList())
            {
                lst.Add(WordPerCategory.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }

        public void AddWordPerCategory(WordPerCategory w)
        {
            db.WordPerCategory_tbl.Add(w.DtoTODal());
            db.SaveChanges();
        }


        //WordType
        public RequestResult GetAllWordsType()
        {

            List<WordType> lst = new List<WordType>();
            foreach (var item in db.WordType_tbl.ToList())
            {
                lst.Add(WordType.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }

        public void AddWordType(WordType w)
        {
            db.WordType_tbl.Add(w.DtoTODal());
            db.SaveChanges();
        }
    }
}
