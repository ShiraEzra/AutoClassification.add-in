using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RequestAnalysis
    {
        public Subject Subject { get; set; }
        public List<SentenceInBody> Body { get; set; }
        public List<Word_tbl> SimiliarwordsExsistDB { get; set; }
        public bool[] IsContainCategoryManagerID { get; set; }
        public RequestAnalysis(int numCategories)
        {
            this.Subject = new Subject();
            this.Body = new List<SentenceInBody>();
            this.SimiliarwordsExsistDB = new List<Word_tbl>();
            this.IsContainCategoryManagerID = new bool[numCategories];
        }
    }
}
