using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PomoControl.DAL.Data;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace PomoControl.API
{
    public class Startup
    {
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            //Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        //public IConfiguration Configuration { get; }
        public IConfigurationRoot Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();

            //services.AddAuthentication();

            //inject context (connection db)
            //services.AddDbContext<PomoContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            //        retry => retry.EnableRetryOnFailure(
            //                maxRetryCount: 2,
            //                maxRetryDelay: TimeSpan.FromSeconds(6),
            //                errorNumbersToAdd: null
            //            ).MigrationsHistoryTable("EFCore_History")); //appsettings.json
            //});

            //Swagger
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1",
            //        new Microsoft.OpenApi.Models.OpenApiInfo
            //        {
            //            Title = "PomoControl API",
            //            Version = "v1",
            //            Description = "API PomoControl with ASP.NET Core",
            //            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            //            {
            //                Email = "henrique_holtz@hotmail.com",
            //                Name = "Henrique Holtz",
            //                Url = new Uri("https://github.com/henriqueholtz")
            //            }
            //        });

            //    string caminhoAplicacao =
            //        PlatformServices.Default.Application.ApplicationBasePath;
            //    string nomeAplicacao =
            //        PlatformServices.Default.Application.ApplicationName;
            //    string caminhoXmlDoc =
            //        Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

            //    c.IncludeXmlComments(caminhoXmlDoc);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Ativando middlewares para uso do Swagger
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json",
            //        "PomoControl API");
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
