using McDonalds.DataAcces.IRepository;
using McDonalds.DataAcces.McDonaldsDBContext;
using McDonalds.DataAcces.Repository;
using McDonalds.Service.IService;
using McDonalds.Service.Service;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace McDonaldsAPI.Extention
{
    public static class Middleware
    {
        public static void AddDBConTextes(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("McDonaldsDB")));
        }
        public static void AddService(this IServiceCollection services)
        {
            services.AddTransient<IBreakfastService, BreakfastService>();
            services.AddTransient<IDessert_BakeryService, Dessert_BakeryService>();
            services.AddTransient<ISandwichesService, SandwichesService>();
            services.AddTransient<ICustomersService, CustomersService>();
        }
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IBreakfastRepository, BreakfastRepository>();
            services.AddTransient<IDesserts_BakeryRepository, Desserts_BakeryRepository>();
            services.AddTransient<ISandwichesRepository, SandwichesRepository>();
            services.AddTransient<ICustomersRepository, CustomersRepository>();
        }
    }
}
