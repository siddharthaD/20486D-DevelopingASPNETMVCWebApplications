using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Cupcakes.Data;
using Cupcakes.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cupcakes
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddTransient<ICupcakeRepository, CupcakeRepository>();

            //string connectionString = "Server=LP000007036997\\SQLEXPRESS;Database=BOPA;Trusted_Connection=True;MultipleActiveResultSets=true";
            //services.AddDbContext<CupcakeContext>(options =>
            //           options.UseSqlServer(connectionString));

            services.AddDbContext<CupcakeContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<CupcakeContext>(options =>
            //        options.UseSqlite("Data Source=cupcake.db"));
            services.AddMvc();
        }

        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, CupcakeContext cupcakeContext)
        {

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "CupcakeRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Cupcake", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
