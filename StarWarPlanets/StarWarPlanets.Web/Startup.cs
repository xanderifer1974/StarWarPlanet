using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarWarPlanets.Repository.Context;

namespace StarWarPlanets.Web
{
    public class Startup
    {
        /// <summary>
        /// Configuração do Acesso ao DbContext
        /// </summary>
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("config.json", optional: false, reloadOnChange: true); //Neste arquivo será colocada a string de conexão com o banco de dados.
            Configuration = builder.Build();//Construi a interface de configuração.
        }       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Configuração da conexão com o banco de dados 
            var connectionString = Configuration.GetConnectionString("StarWarPlanetsDB");
            services.AddDbContext<StarWarPlanetContext>(option => option.UseMySql(connectionString,
                                                                             m => m.MigrationsAssembly("StarWarPlanets.Repository")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseMvc();
        }
    }
}
