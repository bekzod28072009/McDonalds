using McDonalds.Domein.Entity.Menu;
using McDonalds.Service.Dto_s.MenuDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.Service.IService
{
    public interface IDessert_BakeryService
    {
        IEnumerable<Desserts_BakeryDto> GetAllAsync();

        Task Add(Desserts_BakeryDto desserts);

        Task Update(int Id, Desserts_BakeryDto desserts);

        Task Delete(int Id);
    }
}
