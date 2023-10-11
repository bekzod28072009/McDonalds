using McDonalds.Domein.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.Domein.Entity.Menu
{
    public class Breakfast : Auditible
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Value { get; set; }
    }
}
