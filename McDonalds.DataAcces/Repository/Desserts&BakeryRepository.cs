using McDonalds.DataAcces.IRepository;
using McDonalds.DataAcces.McDonaldsDBContext;
using McDonalds.Domein.Entity.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.DataAcces.Repository
{
    public class Desserts_BakeryRepository : IDesserts_BakeryRepository
    {
        private readonly AppDBContext dbContext;

        public Desserts_BakeryRepository(AppDBContext Context)
        {
            dbContext = Context;
        }

        public async Task Add(Desserts_Bakery desserts)
        {
            dbContext.desserts.Add(desserts);
            dbContext.SaveChanges();
        }

        public async Task Delete(int Id)
        {
            var dessert = dbContext.desserts.FirstOrDefault(x => x.Id == Id);
            dbContext.desserts.Remove(dessert);
            dbContext.SaveChangesAsync();
        }

        public IEnumerable<Desserts_Bakery> GetAllAsync()
            => dbContext.desserts.ToList();

        public async Task Update(int Id, Desserts_Bakery desserts)
        {
            var dessert = dbContext.desserts.FirstOrDefault(x => x.Id == Id);
            desserts.Id = Id;

            dbContext.desserts.Attach(dessert).CurrentValues.SetValues(desserts);
            dbContext.SaveChanges();
        }
    }
}
