using McDonalds.Service.Dto_s.MenuDto;
using McDonalds.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McDonaldsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Dessert_BakeryController : ControllerBase
    {
        public readonly IDessert_BakeryService service;
        public Dessert_BakeryController(IDessert_BakeryService dessertsService)
        {
            service = dessertsService;
        }
        [HttpGet]
        public async Task<IEnumerable<Desserts_BakeryDto>> GetAll()
            => service.GetAllAsync();

        [HttpPost]
        public void Add([FromForm] Desserts_BakeryDto desserts)
            => service.Add(desserts);

        [HttpPut]
        public async Task Update([FromForm] int a, Desserts_BakeryDto desserts)
            => await service.Update(a, desserts);

        [HttpDelete]
        public Task Delete([FromForm] int a)
            => service.Delete(a);
    }
}
