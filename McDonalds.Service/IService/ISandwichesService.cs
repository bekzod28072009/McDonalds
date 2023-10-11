using McDonalds.Domein.Entity.Menu;
using McDonalds.Service.Dto_s.MenuDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.Service.IService
{
    public interface ISandwichesService
    {
        IEnumerable<SandwichesDto> GetAllAsync();

        Task Add(SandwichesDto sandwiches);

        Task Update(int Id, SandwichesDto sandwiches);

        Task Delete(int Id);
    }
}
