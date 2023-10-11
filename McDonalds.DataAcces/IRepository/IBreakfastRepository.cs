using McDonalds.Domein.Entity.Menu;
using McDonalds.Domein.Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.DataAcces.IRepository
{
    public interface IBreakfastRepository
    {
        IEnumerable<Breakfast> GetAllAsync();

        Task Add(Breakfast breakfast);

        Task Update(int Id, Breakfast breakfast);

        Task Delete(int Id);
    }
}
