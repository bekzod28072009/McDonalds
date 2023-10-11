using McDonalds.Domein.Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.DataAcces.IRepository
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> GetAllAsync();

        Task Add(Customer customer);

        Task Update(int Id, Customer customer);

        Task Delete(int Id);
    }
}
