using McDonalds.DataAcces.IRepository;
using McDonalds.DataAcces.McDonaldsDBContext;
using McDonalds.DataAcces.Model;
using McDonalds.DataAcces.Repository;
using McDonalds.Service.IService;
using McDonalds.Service.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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

        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"McDonalds project API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the next input below. \r\n\r\n Example : \"Bearer 1234abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                        
                    }
                });
            });
        }

        public static void AddConfigurationIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApiUser, Role>(q => q.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();
        }

        public static void AddConfigurationJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");

            var key = jwtSettings.GetSection("Key").Value;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

        }
    }
}
