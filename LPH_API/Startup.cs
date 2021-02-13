using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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


namespace LPH_API
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

            //configuramos la injeccion encargada de mappear entidades.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //  services.AddDbContext<LPHDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LPHDB")));

            services.AddDbContext<LPHDBContext>(options => { options.UseMySQL(Configuration.GetConnectionString("LPHDB")); options.UseLazyLoadingProxies(); });

            //Agregamos y configuramos la base de datos.

            //configuramos la contraseña opcion

            services.Configure<PasswordOptions>(conf => Configuration.GetSection("PasswordOptions").Bind(conf));

            #region Entidades de dominio

            services.AddScoped(typeof(IService<>), typeof(BaseService<>));
            //services.AddTransient<IRepository<Address>, RepositoryBase<Address, LPHDBContext>>();
            //services.AddTransient<IRepository<User>, RepositoryBase<User, LPHDBContext>>();
            //services.AddTransient<IRepository<Catalog>, RepositoryBase<Catalog, LPHDBContext>>();
            //services.AddTransient<IRepository<Customer>, RepositoryBase<Customer, LPHDBContext>>();
            //services.AddTransient<IRepository<Order>, RepositoryBase<Order, LPHDBContext>>();
            //services.AddTransient<IRepository<Picture>, RepositoryBase<Picture, LPHDBContext>>();
            //services.AddTransient<IRepository<Product>, RepositoryBase<Product, LPHDBContext>>();
            //services.AddTransient<IRepository<Tool>, RepositoryBase<Tool, LPHDBContext>>();
            //services.AddTransient<IRepository<UsersPictures>, RepositoryBase<UsersPictures, LPHDBContext>>();
            services.AddTransient<ISecurityService, SecurityServices>();
            services.AddSingleton<IPasswordService, PasswordService>();


            #endregion

            #region BotImplementation

            //services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();

            //// Create the bot as a transient. In this case the ASP Controller is expecting an IBot.
            //services.AddTransient<IBot, PrinBo>();
            #endregion

            services.AddScoped(typeof(IService<>), typeof(BaseService<>));

            //services.AddTransient<IService<Address>, BaseService<Address>>();
            //services.AddTransient<IService<User>, BaseService<User>>();
            //services.AddTransient<IService<Catalog>, BaseService<Catalog>>();
            //services.AddTransient<IService<Customer>, BaseService<Customer>>();
            //services.AddTransient<IService<Order>, BaseService<Order>>();
            //services.AddTransient<IService<Picture>, BaseService<Picture>>();
            //services.AddTransient<IService<Product>, BaseService<Product>>();
            //services.AddTransient<IService<Tool>, BaseService<Tool>>();
            //services.AddTransient<IService<UsersPictures>, BaseService<UsersPictures>>();
            services.AddTransient<ISecurityService, SecurityServices>();
            services.AddSingleton<IPasswordService, PasswordService>();


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

                    context.Database.Migrate();
                }
            }
        }
    }
}
