﻿using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class Category
    {
        public int ID_category { get; set; }
        public string Name_category { get; set; }
        public string Mail_category { get; set; }
        public string FolderPath_category { get; set; }
        public string Descriptiopn_category { get; set; }

        public Category_tbl DtoTODal()
        {
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<Category, Category_tbl>()
               );
            var mapper = new Mapper(config);
            return mapper.Map<Category_tbl>(this);
        }

        public static Category DalToDto(Category_tbl c)
        {
            var config = new MapperConfiguration(cfg =>
                 cfg.CreateMap<Category_tbl, Category>()
             );
            var mapper = new Mapper(config);
            return mapper.Map<Category>(c);
        }

        public override string ToString()
        {
            return this.Name_category;
        }
    }
}
