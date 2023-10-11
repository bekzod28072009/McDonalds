using McDonalds.Domein.Entity.Menu;
using McDonalds.Service.Dto_s.MenuDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.Service.IService
{
    public interface IBreakfastService
    {
        IEnumerable<BreakfastDto> GetAllAsync();

        Task Add(BreakfastDto breakfast);

        Task Update(int Id, BreakfastDto breakfast);

        Task Delete(int Id);
    }
}
