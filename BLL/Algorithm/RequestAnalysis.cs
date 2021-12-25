using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class RequestAnalysis
    {
        public List<string> NamesInSubject { get; set; }
        public List<string> NormalizedSubjectWords { get; set; }
        public BodyContent[] bodyAnalysis { get; set; }
        public RequestAnalysis()
        {
            this.NamesInSubject = new List<string>();
            this.NormalizedSubjectWords = new List<string>();
        }
    }
}
