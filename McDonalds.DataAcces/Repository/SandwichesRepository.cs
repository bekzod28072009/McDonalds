using McDonalds.DataAcces.IRepository;
using McDonalds.DataAcces.McDonaldsDBContext;
using McDonalds.Domein.Entity.Menu;
using McDonalds.Domein.Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.DataAcces.Repository
{
    public class SandwichesRepository : ISandwichesRepository
    {
        private readonly AppDBContext dbContext;
        public SandwichesRepository(AppDBContext Context)
        {
            dbContext = Context;
        }
        public async Task Add(Sandwiches sandwiches)
        {
            dbContext.sandwiches.Add(sandwiches);
            dbContext.SaveChanges();
        }

        public async Task Delete(int Id)
        {
            var sandwich = dbContext.sandwiches.FirstOrDefault(x => x.Id == Id);
            dbContext.Remove(sandwich);
            dbContext.SaveChangesAsync();
        }

        public IEnumerable<Sandwiches> GetAllAsync()
            => dbContext.sandwiches.ToList();

        public async Task Update(int Id, Sandwiches sandwiches)
        {
            var sandwich = dbContext.sandwiches.FirstOrDefault(x => x.Id == Id);
            sandwiches.Id = Id;

            dbContext.Attach(sandwich).CurrentValues.SetValues(sandwiches);
            dbContext.SaveChanges();
        }
    }
}
