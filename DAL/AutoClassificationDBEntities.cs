using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AutoClassificationDBEntities:AutomaticClassificationDBEntities
    {
        public static AutoClassificationDBEntities Instance { get; } = new AutoClassificationDBEntities();
        protected AutoClassificationDBEntities():base()
        {

        }

    }
}
