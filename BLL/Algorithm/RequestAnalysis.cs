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
        public List<string> Similarwords { get; set; }
        public float[] ProbabilitybSubjectForCategory { get; set; }  //init on use
        public BodyContent[] BodyAnalysis { get; set; }
        public RequestAnalysis()
        {
            this.NormalizedSubjectWords = new List<string>();
            this.Similarwords = new List<string>();
        }
    }
}
