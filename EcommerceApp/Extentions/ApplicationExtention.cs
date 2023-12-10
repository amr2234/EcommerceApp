using E_Core.Interfaces;
using EcommerceApp.Errors;
using EcommerceClasslib.Data;
using EcommerceClasslib.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Extentions
{
    public static class ApplicationExtention
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
        {
           

            // Add services to the container.

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<EContext>(options =>
                options.UseSqlServer(config.GetConnectionString("EcContextconnectionstring"), b => b.MigrationsAssembly("EcommerceClasslib")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped(typeof(IGenaricRepositiory<>), typeof(GenaricRepository<>));
            services.Configure<ApiBehaviorOptions>(
                option => option.InvalidModelStateResponseFactory = actioncontext =>
                {
                    var error = actioncontext.ModelState.Where(e => e.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();
                    var errorresponse = new ApiValidationErrorResponse
                    {
                        Errors = error
                    };
                    return new BadRequestObjectResult(errorresponse);
                });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });
            return services;
        }

    }
}
