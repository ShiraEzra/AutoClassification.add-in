﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BodyContent
    {
        public List<string> NamesInBody { get; set; }
        public List<string> NormalizedBodyWords { get; set; }
        public float[] ProbabilitybSentenceForCategory { get; set; }

        public BodyContent(int numCategories)
        {
            this.NamesInBody = new List<string>();
            this.NormalizedBodyWords = new List<string>();
            this.ProbabilitybSentenceForCategory = new float[numCategories];
        }
    }
}
