using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WordPerCategory
    {
        public int ID_wordPerCategory { get; set; }
        public int ID_word { get; set; }
        public int ID_category { get; set; }
        public Nullable<int> AmountOfUse { get; set; }
        public Nullable<float> MatchPercentage { get; set; }  //מספר ההופעות של המילה בקטגוריה זו לחלק למספר הפניות לקטגוריה זו

  
        public WordPerCategory_tbl DtoTODal()
        {
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<WordPerCategory, WordPerCategory_tbl>()
               );
            var mapper = new Mapper(config);
            return mapper.Map<WordPerCategory_tbl>(this);
        }

        public static WordPerCategory DalToDto(WordPerCategory_tbl w)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<WordPerCategory_tbl, WordPerCategory>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<WordPerCategory>(w);
        }
    }
}
