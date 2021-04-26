using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using LPH.Core.Entities;
using LPH.Core.Interfaces;
using LPH.Infrastructure.Data;
using LPH.Infrastructure.Filters;
using LPH.Infrastructure.Repositories;
using LPH.Infrastructure.Services;
using System;
using System.IO;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LPH.Core.Services;
using MySql.Data.EntityFrameworkCore;
using LPH.Infrastructure.Options;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.AspNetCore.Authorization;
using LPH.Api.Controllers;

namespace LPH.Api
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

            


            services.AddControllers(option => option.Filters.Add<GlobalExceptionFilter>()).AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("ownerOrAdmin", policy =>
            //        policy.Requirements.Add(new PropertyOrAdministerRequirement()));
            //});


            //configuramos la injeccion encargada de mappear entidades.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<LPHDBContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("LPHDB")); options.UseLazyLoadingProxies(); }) ;

            services.Configure<PasswordOptions>(conf => Configuration.GetSection("PasswordOptions").Bind(conf));

            #region Entidades de dominio
                     
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IService<>), typeof(BaseService<>));
            services.AddTransient(typeof(ISecurityRepositor),typeof(SecurityRepository));
            services.AddTransient<ISecurityService, SecurityServices>();
            services.AddSingleton<IPasswordService, PasswordService>();
           // services.AddScoped<IAuthorizationHandler, PropertyOrAdministerAuthorizationHandler>();
          
            #endregion

            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "LPH API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                doc.IncludeXmlComments(xmlPath);
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Authentication:Issuer"],
                    ValidAudience = Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))


                };
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            UpdateDatabase(app);
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "LPH API Documentation");


            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public string Hash(string password)
        {


            //PBKDF2 implementation
            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                16,
                1000
                ))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(32));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{1000}.{salt}.{key}";
            }
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<LPHDBContext>())
                {
                    context.Database.EnsureCreated();
                   
                   
                }
            }
        }
    }
}
