using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SentenceInBody
    {
        public List<string> NormalizedBodyWords { get; set; }
        public double[] ProbabilitybSentenceForCategory { get; set; } //init on use

        public SentenceInBody()
        {
            this.NormalizedBodyWords = new List<string>();
        }
    }
}
