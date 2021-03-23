using Cupcakes.Data;
using Cupcakes.Repositories;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cupcakes
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            //Microsoft.AspNetCore.Mvc.MvcOptions.EnableEndpointRouting = false;
           // var _ctxConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BakeriesDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            _ = services.AddTransient<ICupcakeRepository, CupcakeRepository>();
            _ = services.AddDbContext<CupcakeContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            _ = services.AddMvc(x => x.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app)
        {
            //_ = cupcakeContext.Database.EnsureCreated();
            //_ = cupcakeContext.Database.EnsureDeleted();

            app.UseStaticFiles();
            
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "CupcakeRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Cupcake", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
