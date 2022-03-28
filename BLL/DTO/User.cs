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
        public string Name_user { get; set; }
        public int ID_premissionLevel { get; set; }
        public Nullable<int> ID_category { get; set; }
        public string ID_user { get; set; }
        public string Password { get; set; }

        AutomaticClassificationDBEntities db = AutomaticClassificationDBEntities.Instance;
        public User()
        {

        }

        public User(User_tbl user_tbl)
        {
            this.Code = user_tbl.Code;
            this.ID_premissionLevel = user_tbl.ID_premissionLevel;
            this.Name_user = user_tbl.Name_user;
            this.ID_category = user_tbl.ID_category == null ? -1 : (int)user_tbl.ID_category;
            this.ID_user = user_tbl.ID_user;
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
        

        public override string ToString()
        {
            return this.Name_user /*+ " (" + GetNameCategoryByID((int)this.ID_category) + " )"*/;
        }

        public string GetNameCategoryByID(int id)
        {
            return db.Category_tbl.FirstOrDefault(c => c.ID_category == id)?.Name_category;
        }
    }
}
