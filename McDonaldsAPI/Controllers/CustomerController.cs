using McDonalds.Service.Dto_s.MenuDto;
using McDonalds.Service.Dto_s.UsersDto;
using McDonalds.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McDonaldsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomersService service;
        public CustomerController(ICustomersService Customerservice)
        {
            service = Customerservice;
        }
        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetAll()
            => service.GetAllAsync();

        [HttpPost]
        public void Add([FromForm] CustomerDto customer)
            => service.Add(customer);

        [HttpPut]
        public async Task Update([FromForm] int a, CustomerDto customer)
            => await service.Update(a, customer);

        [HttpDelete]
        public Task Delete([FromForm] int a)
            => service.Delete(a);
    }
}
