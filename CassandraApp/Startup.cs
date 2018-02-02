using Domain.PaletesCarregamento;
using Infra.Cassandra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CassandraApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();

            services.AddScoped<CassandraDbContext, CassandraDbContext>();
            services.AddTransient<IPaleteCarregamentoRepositorio, PaleteCarregamentoRepositorio>();
            services.AddTransient<IPaleteCarregamentoBuscar, PaleteCarregamentoBuscar>();
            services.AddTransient<IPaleteCarregamentoSalvar, PaleteCarregamentoSalvar>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
            
            app.UseMvc();

            Configuracores.Servidor = Configuration.GetSection("CassandraConnection:ConnectionString").Value;
            Configuracores.Cluster = Configuration.GetSection("CassandraConnection:Cluster").Value;
        }
    }
}