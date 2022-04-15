using AutoMapper;
using LojaQuadrinhos.Domain.Entities;
using LojaQuadrinhos.Infra.Context;
using LojaQuadrinhos.Infra.Interfaces;
using LojaQuadrinhos.Infra.Repositories;
using LojaQuadrinhos.Services.Cryptography.Algorithms;
using LojaQuadrinhos.Services.Cryptography.Interfaces;
using LojaQuadrinhos.Services.DTO;
using LojaQuadrinhos.Services.Interfaces;
using LojaQuadrinhos.Services.Services;
using LojaQuadrinhos.Token;
using LojaQuadrinhos.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace LojaQuadrinhos
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
            services.AddControllers();


            #region JWT

            var secretKey = Configuration["Jwt:Key"];

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            #endregion

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
                cfg.CreateMap<UpdateUserViewModel, UserDTO>().ReverseMap();

                cfg.CreateMap<ComicBook, ComicBookDTO>().ReverseMap();
                cfg.CreateMap<CreateComicViewModel, ComicBookDTO>().ReverseMap();
                cfg.CreateMap<UpdateComicViewModel, ComicBookDTO>().ReverseMap();

                cfg.CreateMap<Sales, SalesDTO>().ReverseMap();                
                cfg.CreateMap<BuyComicViewModel, SalesDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            services.AddDbContext<ModelContext>(options => options
               .UseNpgsql(Configuration["ConnectionStrings:ManagerAPIPostgres"]), ServiceLifetime.Transient);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IComicBookService, ComicBookService>();
            services.AddScoped<IComicBookRepository, ComicBookRepository>();

            services.AddScoped<ISalesService, SalesService>();
            services.AddScoped<ISalesRepository, SalesRepository>();

            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IAesCryptography, AesCryptography>();

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Loja de quadrinhos.",
                    Version = "v1",
                    Description = "",
                    Contact = new OpenApiContact
                    {
                        Name = "Gabriel",
                        Email = "ga.jaimealves@gmail.com",
                        Url = new Uri("https://github.com/gajalves")
                    },
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor utilize Bearer <TOKEN>",
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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LojaQuadrinhos v1"));
            }

            app.UseHttpsRedirection();

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
