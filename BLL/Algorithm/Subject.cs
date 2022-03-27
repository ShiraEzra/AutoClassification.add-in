using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Subject
    {
        public List<string> NormalizedSubjectWords { get; set; }
        public double[] ProbabilitybSubjectForCategory { get; set; }  //init on use

        public Subject()
        {
            this.NormalizedSubjectWords = new List<string>();
        }
    }
}
