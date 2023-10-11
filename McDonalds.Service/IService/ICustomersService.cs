using McDonalds.Domein.Entity.Users;
using McDonalds.Service.Dto_s.MenuDto;
using McDonalds.Service.Dto_s.UsersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.Service.IService
{
    public interface ICustomersService
    {
        IEnumerable<CustomerDto> GetAllAsync();

        Task Add(CustomerDto customer);

        Task Update(int Id, CustomerDto customer);

        Task Delete(int Id);
    }
}
