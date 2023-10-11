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
    public class Dessert_BakeryService : IDessert_BakeryService
    {
        private readonly IDesserts_BakeryRepository repository;
        private readonly IMapper mapper;
        public Dessert_BakeryService(IDesserts_BakeryRepository repository1, IMapper mapper1)
        {
            repository = repository1;
            mapper = mapper1;
        }
        public Task Add(Desserts_BakeryDto desserts)
            => repository.Add(mapper.Map<Desserts_Bakery>(desserts));

        public Task Delete(int Id)
            => repository.Delete(Id);

        public IEnumerable<Desserts_BakeryDto> GetAllAsync()
            => mapper.Map<List<Desserts_BakeryDto>>(repository.GetAllAsync());

        public Task Update(int Id, Desserts_BakeryDto desserts)
            => repository.Update(Id, mapper.Map<Desserts_Bakery>(desserts));
    }
}
