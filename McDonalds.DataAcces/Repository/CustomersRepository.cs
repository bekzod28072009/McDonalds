using McDonalds.DataAcces.IRepository;
using McDonalds.DataAcces.McDonaldsDBContext;
using McDonalds.Domein.Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.DataAcces.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly AppDBContext dbContext;
        public CustomersRepository(AppDBContext context)
        {
            dbContext = context;
        }
        public async Task Add(Customer customer)
        {
            dbContext.customers.Add(customer);
            dbContext.SaveChanges();
        }

        public async Task Delete(int Id)
        {
            var customer = dbContext.customers.FirstOrDefault(x => x.Id == Id);
            dbContext.Remove(customer);
            dbContext.SaveChangesAsync();
        }

        public IEnumerable<Customer> GetAllAsync()
            => dbContext.customers.ToList();

        public async Task Update(int Id, Customer customer)
        {
            var customers = dbContext.customers.FirstOrDefault(x => x.Id == Id);
            customer.Id = Id;

            dbContext.Attach(customers).CurrentValues.SetValues(customer);
            dbContext.SaveChanges();
        }
    }
}
