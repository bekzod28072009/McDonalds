using McDonalds.Service.Dto_s.MenuDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.Service.Dto_s.UsersDto
{
    public class CustomerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Payment { get; set; }

        public List<BreakfastDto>? breakfasts { get; set; }

        public List<SandwichesDto>? sandwiches { get; set; }

        public List<Desserts_BakeryDto>? desserts { get; set; }

        public CustomerDto()
        {
            breakfasts = new List<BreakfastDto>();
            sandwiches = new List<SandwichesDto>();
            desserts = new List<Desserts_BakeryDto>();
        }
    }
}
