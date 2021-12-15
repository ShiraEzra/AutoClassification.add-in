using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WordType
    {
        public int ID_wordType { get; set; }
        public string Description { get; set; }

        public WordType_tbl DtoTODal()
        {
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<WordType, WordType_tbl>()
               );
            var mapper = new Mapper(config);
            return mapper.Map<WordType_tbl>(this);
        }

        public static WordType DalToDto(WordType_tbl w)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<WordType_tbl, WordType>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<WordType>(w);
        }
    }
}
