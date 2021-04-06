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
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using PomoControl.Infraestructure.Context;
using Microsoft.OpenApi.Models;
using System.Linq;
using PomoControl.Service.Interfaces;
using PomoControl.Service.Services;
using PomoControl.Infraestructure.Repositories;
using PomoControl.Infraestructure.Interfaces;
using AutoMapper;
using PomoControl.Domain;
using PomoControl.Service.DTO;
using PomoControl.Service.ViewModels.User;
using PomoControl.Service.ViewModels.Account;
using PomoControl.Service.ViewModels.Token;
using EscNet.DependencyInjection.IoC.Cryptography;
using PomoControl.Core.Helpers;
using PomoControl.API.Middlewares;

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

            #region AutoMapper and your DI
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                //cfg.CreateMap<User, TokenViewModel>().ReverseMap();
                cfg.CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
                cfg.CreateMap<SignInViewModel, User>().ReverseMap();
                cfg.CreateMap<SignUpViewModel, User>().ReverseMap();
                cfg.CreateMap<UserSimpleDTO, User>().ReverseMap();
                cfg.CreateMap<SignInViewModel, AccountDTO>().ReverseMap();
                cfg.CreateMap<SignUpViewModel, AccountDTO>().ReverseMap();
                //cfg.CreateMap<User, UserDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            #endregion

            #region Dependency Injection
            services.AddHttpClient();
            services.AddRijndaelCryptography(Configuration["Cryptography:Key"]);
            services.AddSingleton<CryptographyHelper>();
            services.AddSingleton(d => Configuration);

            //services.AddTransient<>(); //It starts a instance per use
            //services.AddSingleton<>(); // It starts a single instance per application
            services.AddScoped<IUserService, UserService>(); //It starts a single instance per request
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IScopeService, ScopeService>();
            services.AddScoped<IScopeRepository, ScopeRepository>();

            services.AddTransient<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            //services.AddScoped<IAccountRepository, AccountRepository>();

            //services.AddScoped<IScopeItemService, ScopeItemService>();
            #endregion

            #region JWT
            var secretKey = Configuration["Jwt:SecretKey"];
            var key = Encoding.ASCII.GetBytes(secretKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => 
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    //ValidateIssuer = false,
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    //ValidIssuers = new List<string>() { "JwtGenerator", "accounts.google.com" },
                    //ValidateAudience = false,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    //ValidAudiences = new List<string>() { "Snd0R2VuZXJhdG9y", "779353502918-02hl7fnucja6m6eec21r82l6st4lh55v.apps.googleusercontent.com" },
                };
            })/*.AddGoogle(x =>
            {
                x.ClientId = "779353502918-khhi4aa617b0ucnq95ee7tg3r8iltubd.apps.googleusercontent.com";
                x.ClientSecret = "DVZv27Ie6qZIQpUk7trq3gKl";
                x.Validate();
            })*/;
            #endregion


            #region DataBase connection
            services.AddDbContext<PomoContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    retry => retry.EnableRetryOnFailure(
                            maxRetryCount: 2,
                            maxRetryDelay: TimeSpan.FromSeconds(6),
                            errorNumbersToAdd: null
                        ).MigrationsHistoryTable("EFCore_History")); //appsettings.json
            }, ServiceLifetime.Transient); //It starts a instance per use
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PomoControl API",
                    Version = "v1",
                    Description = "API PomoControl with ASP.NET Core",
                    Contact = new OpenApiContact
                    {
                        Name = "Henrique Holtz",
                        Email = "henrique_holtz@hotmail.com",
                        Url = new Uri("https://henriqueholtz.github.io/")
                    },
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please, using Bearer <TOKEN>",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            #region Swagger
            //Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "PomoControl API");
            });
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthentication();
            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
