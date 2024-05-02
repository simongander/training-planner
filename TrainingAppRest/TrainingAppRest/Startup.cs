using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrainingAppBL;
using TrainingAppBL.Interfaces;
using TrainingAppDAL;
using TrainingAppDAL.Interfaces;

namespace TrainingAppRest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [System.Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            services.AddMemoryCache();

            services.AddControllers();


            services.AddCors(options =>
            {
                options.AddPolicy("AppOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:8100")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddTransient(typeof(ITrainingDbContext), (sp) => new TrainingDbContextInMemory());
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(ITrainingTypeRepository), typeof(TrainingTypeRepository));
            services.AddTransient(typeof(ITrainingRepository), typeof(TrainingRepository));
            services.AddTransient(typeof(ITeamRepository), typeof(TeamRepository));
            services.AddTransient(typeof(ITeamMembershipRepository), typeof(TeamMembershipRepository));

            services.AddOpenApiDocument();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            
            app.UseHttpsRedirection();
            //app.UseMiddleware<AuthenticationMiddleware>();

            app.UseRouting();
            app.UseCors("AppOrigin");
            app.UseEndpoints(c => c.MapDefaultControllerRoute());

            app.UseOpenApi();
            app.UseSwaggerUi();

        }
    }
}
