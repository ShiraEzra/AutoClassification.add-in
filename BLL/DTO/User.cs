using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class User
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Categoty { get; set; }

        static AutomaticClassificationDBEntities db = AutomaticClassificationDBEntities.Instance;
        public User()
        {

        }

        public User(User_tbl user_tbl)
        {
            this.Code = user_tbl.Code;
            this.Name = user_tbl.Name;
            this.Categoty = user_tbl.Categoty;
        }

        public User_tbl DtoTODal()
        {
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<User, User_tbl>()
               );
            var mapper = new Mapper(config);
            return mapper.Map<User_tbl>(this);
        }

        public static User DalToDto(User_tbl u)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<User_tbl, User>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<User>(u);
        }

        public static bool IsExsistUser()
        {
            if (db.User_tbl.Count() > 0)
                return true;
            return false;
        }
      

        public override string ToString()
        {
            return this.Name /*+ " (" + GetNameCategoryByID((int)this.ID_category) + " )"*/;
        }

        public string GetNameCategoryByID(int id)
        {
            return db.Category_tbl.FirstOrDefault(c => c.ID_category == id)?.Name_category;
        }

        public void Add()
        {
            db.User_tbl.Add(this.DtoTODal());
            db.SaveChanges();
        }

        public void Update()
        {
            User_tbl user_tbl = db.User_tbl.Single(u => u.Code == this.Code);
            user_tbl.Name = this.Name;
            user_tbl.Categoty = this.Categoty;
            db.SaveChanges();
        }
    }
}
