using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class Manager
    {
        public int Code { get; set; }
        public string Name_user { get; set; }
        public string ID_user { get; set; }
        public string Password { get; set; }

        static AutomaticClassificationDBEntities db = AutomaticClassificationDBEntities.Instance;


        public Manager_tbl DtoTODal()
        {
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<Manager, Manager_tbl>()
               );
            var mapper = new Mapper(config);
            return mapper.Map<Manager_tbl>(this);
        }

        public static Manager DalToDto(Manager_tbl m)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<Manager_tbl, Manager>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<Manager>(m);
        }

        public void Add()
        {
            db.Manager_tbl.Add(this.DtoTODal());
            db.SaveChanges();
        }

        public void Update()
        {
            Manager_tbl manager_tbl = db.Manager_tbl.Single(u => u.Code == this.Code);
            manager_tbl.Name_user = this.Name_user;
            manager_tbl.ID_user = this.ID_user;
            manager_tbl.Password = this.Password;
            db.SaveChanges();
        }
    }
}
