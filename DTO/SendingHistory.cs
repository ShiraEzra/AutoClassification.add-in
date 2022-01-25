using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SendingHistory
    {
        public int ID_sendingHistory { get; set; }
        public int ID_category { get; set; }
        public int ID_emailRequest { get; set; }
        public System.DateTime Date { get; set; }
        public int ID_StatusSending { get; set; }
        public Nullable<int> SentFrom { get; set; }
        public Nullable<float> Precision { get; set; }

     
        public SendingHistory_tbl DtoTODal()
        {
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<SendingHistory, SendingHistory_tbl>()
               );
            var mapper = new Mapper(config);
            return mapper.Map<SendingHistory_tbl>(this);
        }

        public static SendingHistory DalToDto(SendingHistory_tbl s)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<SendingHistory_tbl, SendingHistory>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<SendingHistory>(s);
        }

    }
}
