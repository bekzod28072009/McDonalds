using AutoMapper;
using McDonalds.DataAcces.IRepository;
using McDonalds.Domein.Entity.Menu;
using McDonalds.Service.Dto_s.MenuDto;
using McDonalds.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.Service.Service
{
    public class BreakfastService : IBreakfastService
    {
        private readonly IBreakfastRepository repository;
        private readonly IMapper mapper;
        public BreakfastService(IBreakfastRepository repository1, IMapper mapper1)
        {
            repository = repository1;
            mapper = mapper1;
        }
        public Task Add(BreakfastDto breakfast)
            => repository.Add(mapper.Map<Breakfast>(breakfast));

        public Task Delete(int Id)
            => repository.Delete(Id);

        public IEnumerable<BreakfastDto> GetAllAsync()
            => mapper.Map<List<BreakfastDto>>(repository.GetAllAsync());

        public Task Update(int Id, BreakfastDto breakfast)
            => repository.Update(Id, mapper.Map<Breakfast>(breakfast));
    }
}
