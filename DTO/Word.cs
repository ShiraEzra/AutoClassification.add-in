using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Word
    {
        public int ID_word { get; set; }
        public string Value_word { get; set; }

        public Word_tbl DtoTODal()
        {
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<Word, Word_tbl>()
               );
            var mapper = new Mapper(config);
            return mapper.Map<Word_tbl>(this);
        }

        public static Word DalToDto(Word_tbl w)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<Word_tbl, Word>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<Word>(w);
        }
    }
}
