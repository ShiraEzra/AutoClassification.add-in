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
        public BodyContent[] bodyAnalysis { get; set; }
        public RequestAnalysis()
        {
            this.NormalizedSubjectWords = new List<string>();
        }
    }
}
