using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class AutomaticClassificationDBEntities
    {
        public static AutomaticClassificationDBEntities Instance { get; } = new AutomaticClassificationDBEntities();

    }
}
