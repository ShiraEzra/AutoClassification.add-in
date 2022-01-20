using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class WordPerRequest
    {
        public int Id_wordPerRequest { get; set; }
        public int Request_id { get; set; }
        public int word_id { get; set; }
        public WordPerRequest_tbl DtoTODal()
        {
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<WordPerRequest, WordPerRequest_tbl>()
               );
            var mapper = new Mapper(config);
            return mapper.Map<WordPerRequest_tbl>(this);
        }

        public static WordPerRequest DalToDto(WordPerRequest_tbl w)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<WordPerRequest_tbl, WordPerRequest>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<WordPerRequest>(w);
        }
    }
}
