using DBRepository;
using DBRepository.Interfaces;
using DBRepository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace RestService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IRepositoryContextFactory, RepositoryContextFactory>();
            services.AddScoped<IUserRepository>(
                p => new UserRepository(
                    Configuration.GetConnectionString("DefaultConnection"),
                    p.GetService<IRepositoryContextFactory>())
            );
            services.AddScoped<IPositionRepository>(
                p => new PositionRepository(
                    Configuration.GetConnectionString("DefaultConnection"),
                    p.GetService<IRepositoryContextFactory>())
            );

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "DefaultApi",
                    "api/{controller}/{action}"
                );
            });
        }
    }
}