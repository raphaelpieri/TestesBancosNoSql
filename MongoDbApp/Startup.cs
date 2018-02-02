using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.PaletesCarregamento;
using Infra.MongoDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MongoDbApp
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

            services.AddScoped<MongoDbContext, MongoDbContext>();
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

            Configuracoes.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            Configuracoes.DatabaseName = Configuration.GetSection("MongoConnection:Database").Value;
            Configuracoes.IsSSl = Convert.ToBoolean(Configuration.GetSection("MongoConnection:IsSSL").Value);
        }
    }
}