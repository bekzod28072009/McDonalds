using AutoMapper;
using McDonalds.DataAcces.IRepository;
using McDonalds.Domein.Entity.Users;
using McDonalds.Service.Dto_s.UsersDto;
using McDonalds.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds.Service.Service
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository repository;
        private readonly IMapper mapper;
        public CustomersService(ICustomersRepository custom, IMapper maper)
        {
            repository = custom;
            mapper = maper;
        }
        public Task Add(CustomerDto customer)
            => repository.Add(mapper.Map<Customer>(customer));

        public Task Delete(int Id)
            => repository.Delete(Id);

        public IEnumerable<CustomerDto> GetAllAsync()
            => mapper.Map<List<CustomerDto>>(repository.GetAllAsync());

        public Task Update(int Id, CustomerDto customer)
            => repository.Update(Id, mapper.Map<Customer>(customer));
    }
}
