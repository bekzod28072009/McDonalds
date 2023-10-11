using McDonalds.Domein.Entity.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.DataAcces.IRepository
{
    public interface ISandwichesRepository
    {
        IEnumerable<Sandwiches> GetAllAsync();

        Task Add(Sandwiches sandwiches);

        Task Update(int Id, Sandwiches sandwiches);

        Task Delete(int Id);
    }
}
