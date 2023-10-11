using AutoMapper;
using McDonalds.Domein.Entity.Menu;
using McDonalds.Domein.Entity.Users;
using McDonalds.Service.Dto_s.MenuDto;
using McDonalds.Service.Dto_s.UsersDto;

namespace McDonaldsAPI.Configurations
{
    public class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            CreateMap<Sandwiches, SandwichesDto>().ReverseMap();
            CreateMap<Breakfast, BreakfastDto>().ReverseMap();
            CreateMap<Desserts_Bakery, Desserts_BakeryDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
