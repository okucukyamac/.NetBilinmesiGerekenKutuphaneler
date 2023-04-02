using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SwaggerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;
using Swashbuckle.Application;

namespace SwaggerApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FluentValidationFatihCakirogluContext>(opts =>
            {
                opts.UseSqlServer(Configuration["ConnectionString"]);
            });

            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("productV1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title="Product Api",
                    Description="Ürün ekleme/silme iþlemlerini gerçekleþtiren api",
                    Contact=new Microsoft.OpenApi.Models.OpenApiConstants
                    {
                        name="Oðuzhan Küçükyamaç",
                        email="okucukyamac@gmail.com",
                        url="www.ok.com"
                    }
                });
            });

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
