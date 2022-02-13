using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BodyContent
    {
        public List<string> NormalizedBodyWords { get; set; }
        public float[] ProbabilitybSentenceForCategory { get; set; } //init on use

        public BodyContent()
        {
            this.NormalizedBodyWords = new List<string>();
        }
    }
}
