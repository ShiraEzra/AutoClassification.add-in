using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class BodyContent
    {
        public List<string> namesInBody { get; set; }
        public List<string> normalizedBodyWords { get; set; }
        public float[] categoryProbability { get; set; }

        public BodyContent(int numCategories)
        {
            this.namesInBody = new List<string>();
            this.normalizedBodyWords = new List<string>();
            this.categoryProbability = new float[numCategories];
        }
    }
}
