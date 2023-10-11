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
    public class BreakfastRepository : IBreakfastRepository
    {
        private readonly AppDBContext dbContext;
        public BreakfastRepository(AppDBContext context)
        {
            dbContext = context;
        }
        public async Task Add(Breakfast breakfast)
        {
            dbContext.breakfasts.Add(breakfast);
            dbContext.SaveChanges();
        }

        public async Task Delete(int Id)
        {
            var breakfast = dbContext.breakfasts.FirstOrDefault(x => x.Id == Id);
            dbContext.breakfasts.Remove(breakfast);
            dbContext.SaveChangesAsync();
        }

        public IEnumerable<Breakfast> GetAllAsync()
            => dbContext.breakfasts.ToList();

        public async Task Update(int Id, Breakfast breakfasts)
        {
            var breakfast = dbContext.breakfasts.FirstOrDefault(x => x.Id == Id);
            breakfasts.Id = Id;

            dbContext.breakfasts.Attach(breakfast).CurrentValues.SetValues(breakfasts);
            dbContext.SaveChanges();
        }
    }
}
