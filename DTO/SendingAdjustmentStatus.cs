using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SendingAdjustmentStatus
    {
        public int ID_SendingAdjustmentStatus { get; set; }
        public string Value_SAStatus { get; set; }

        public SendingAdjustmentStatus_tbl DtoTODal()
        {
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<SendingAdjustmentStatus, SendingAdjustmentStatus_tbl>()
               );
            var mapper = new Mapper(config);
            return mapper.Map<SendingAdjustmentStatus_tbl>(this);
        }

        public static SendingAdjustmentStatus DalToDto(SendingAdjustmentStatus_tbl s)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<SendingAdjustmentStatus_tbl, SendingAdjustmentStatus>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<SendingAdjustmentStatus>(s);
        }
    }
}
