using McDonalds.Service.Dto_s.MenuDto;
using McDonalds.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McDonaldsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakfastController : ControllerBase
    {
        public readonly IBreakfastService service;
        public BreakfastController(IBreakfastService breakservice)
        {
            service = breakservice;
        }
        [HttpGet]
        public async Task<IEnumerable<BreakfastDto>> GetAll()
            => service.GetAllAsync();

        [HttpPost]
        public void Add([FromForm] BreakfastDto breakfast)
            => service.Add(breakfast);

        [HttpPut]
        public async Task Update([FromForm] int a, BreakfastDto breakfast)
            => await service.Update(a, breakfast);

        [HttpDelete]
        public Task Delete([FromForm] int a)
            => service.Delete(a);
    }
}
