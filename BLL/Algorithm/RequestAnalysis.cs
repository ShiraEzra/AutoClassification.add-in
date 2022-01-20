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
        public List<string> NormalizedSubjectWords { get; set; }
        public List<Word_tbl> SimiliarwordsExsistDB { get; set; }
        public float[] ProbabilitybSubjectForCategory { get; set; }
        public BodyContent[] BodyAnalysis { get; set; }
        public RequestAnalysis()
        {
            this.NormalizedSubjectWords = new List<string>();
            this.SimiliarwordsExsistDB = new List<Word_tbl>();
        }
    }
}
