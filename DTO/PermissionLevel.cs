using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PermissionLevel
    {
        public int ID_permissionLevel { get; set; }
        public string Value_pl { get; set; }

        public PermissionLevel_tbl DtoTODal()
        {
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<PermissionLevel, PermissionLevel_tbl>()
               );
            var mapper = new Mapper(config);
            return mapper.Map<PermissionLevel_tbl>(this);
        }

        public static PermissionLevel DalToDto(PermissionLevel_tbl p)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<PermissionLevel_tbl, PermissionLevel>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<PermissionLevel>(p);
        }
    }
}
