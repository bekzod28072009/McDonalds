using McDonalds.Service.Dto_s.MenuDto;
using McDonalds.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McDonaldsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SandwichesController : ControllerBase
    {
        public readonly ISandwichesService service;
        public SandwichesController(ISandwichesService sandwichesService)
        {
            service = sandwichesService;
        }
        [HttpGet]
        public async Task<IEnumerable<SandwichesDto>> GetAll()
            => service.GetAllAsync();

        [HttpPost]
        public void Add([FromForm] SandwichesDto sandwiches)
            => service.Add(sandwiches);

        [HttpPut]
        public async Task Update([FromForm] int a, SandwichesDto sandwiches)
            => await service.Update(a, sandwiches);

        [HttpDelete]
        public Task Delete([FromForm]int a)
            => service.Delete(a);
    }
}
