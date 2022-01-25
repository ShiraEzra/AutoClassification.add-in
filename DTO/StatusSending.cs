using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StatusSending
    {
        public int ID_StatusSending { get; set; }
        public string Description_StatusSending { get; set; }

        public StatusSending_tbl DtoTODal()
        {
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<StatusSending, StatusSending_tbl>()
               );
            var mapper = new Mapper(config);
            return mapper.Map<StatusSending_tbl>(this);
        }

        public static StatusSending DalToDto(StatusSending_tbl s)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<StatusSending_tbl, StatusSending>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<StatusSending>(s);
        }
    }
}
