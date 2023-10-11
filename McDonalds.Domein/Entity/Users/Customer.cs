using McDonalds.Domein.Common;
using McDonalds.Domein.Entity.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.Domein.Entity.Users
{
    public class Customer : Auditible
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Payment { get; set; }

        public List<Breakfast>? breakfasts { get; set; }

        public List<Sandwiches>? sandwiches { get; set; }

        public List<Desserts_Bakery>? desserts { get; set; }

        public Customer()
        {
            breakfasts = new List<Breakfast>();
            sandwiches = new List<Sandwiches>();
            desserts = new List<Desserts_Bakery>();
        }
    }
}
