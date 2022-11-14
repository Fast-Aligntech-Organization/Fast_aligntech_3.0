
using Fast.Core.Services;
using Fast.Infrastructure.Data;
using Fast.Infrastructure.Filters;
using Fast.Infrastructure.Repositories;
using Fast.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Identity;



namespace Fast.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                 builder
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());
            });

            services.AddControllers(option => option.Filters.Add<GlobalExceptionFilter>()).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<ApplicationDbContext>(options => { options.UseNpgsql(Configuration.GetConnectionString("LPHDB_postgres_tocaltest")); options.UseLazyLoadingProxies(); options.EnableDetailedErrors(); }) ;
          //services.AddDbContext<LPHDBContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("LPHDB")); options.UseLazyLoadingProxies(); });

            services.Configure<PasswordOptions>(conf => Configuration.GetSection("PasswordOptions").Bind(conf));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            #region Entidades de dominio


            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddSingleton(typeof(IValidatorService<>), typeof(BaseValidatorService<>));
            services.AddTransient(typeof(ISecurityRepositor), typeof(AccountRepository));
            services.AddTransient<ISecurityService, SecurityServices>();
            services.AddSingleton<IPasswordService, PasswordService>();

           


            #endregion

            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Fast Api", Version = "v1" });
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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UpdateDatabase();
                app.AddAdminister(Configuration);
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

           

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Fast Api Documentation");


            });

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(async context =>
            {
                context.Response.Redirect("swagger");
            });
        }

      
    }

    public static class StartupExtencions
    {
        public static IApplicationBuilder UpdateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
               .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {

                    //var result = context.Database.CanConnect();

                    //var createscrip = context.Database.GenerateCreateScript();

                   //context.Database.Migrate();


                }


            }
               
            return app;
        }

        public static IApplicationBuilder AddAdminister(this IApplicationBuilder app, IConfiguration configuration)
        {
            using (var serviceScope = app.ApplicationServices
               .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {

                    var password = serviceScope.ServiceProvider.GetService<IPasswordService>();

                    PrivateUser administer = new PrivateUser();


                    administer.Email = configuration["Administer:email"].ToString();
                    administer.PhoneNumber = configuration["Administer:telefono"].ToString();
                    administer.Name = configuration["Administer:nombre"].ToString(); ;
                    administer.Birthday = DateTime.Parse(configuration["Administer:fechaNacimiento"].ToString());
                    administer.Lastname = configuration["Administer:apellido"].ToString();
                    administer.PasswordHash = password.Hash(configuration["Administer:password"].ToString());
                    administer.Clock = configuration["Administer:clock"];
                    var user = context.Users.FirstOrDefault(u => u.Email == administer.Email);

                    IdentityRole role = new IdentityRole();

                   



                    if (user == null)
                    {
                        context.Users.Add(administer);

                        context.SaveChanges();
                    }

                   context.Database.CloseConnection();

                }


            }

            return app;
        }
    }

}
