using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        public int ID_user { get; set; }
        public string Name_user { get; set; }
        public int ID_premissionLevel { get; set; }

  
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
    }
}
