using McDonalds.Domein.Entity.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.DataAcces.IRepository
{
    public interface IDesserts_BakeryRepository
    {
        IEnumerable<Desserts_Bakery> GetAllAsync();

        Task Add(Desserts_Bakery desserts);

        Task Update(int Id, Desserts_Bakery desserts);

        Task Delete(int Id);
    }
}
