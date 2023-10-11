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
    public class SandwichesService : ISandwichesService
    {
        private readonly ISandwichesRepository repository;
        private readonly IMapper mapper;
        public SandwichesService(ISandwichesRepository repository1, IMapper mapper1)
        {
            repository = repository1;
            mapper = mapper1;
        }
        public Task Add(SandwichesDto sandwiches)
            => repository.Add(mapper.Map<Sandwiches>(sandwiches));

        public Task Delete(int Id)
            => repository.Delete(Id);

        public IEnumerable<SandwichesDto> GetAllAsync()
            => mapper.Map<List<SandwichesDto>>(repository.GetAllAsync());

        public Task Update(int Id, SandwichesDto sandwiches)
            => repository.Update(Id, mapper.Map<Sandwiches>(sandwiches));
    }
}
