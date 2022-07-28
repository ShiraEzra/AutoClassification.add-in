using System.Collections.Generic;

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
