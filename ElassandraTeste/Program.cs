using System;
using Domain.PaletesCarregamento;
using Infra.Elassandra;
using Infra.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using PaleteCarregamentoRepositorio = Infra.Elassandra.PaleteCarregamentoRepositorio;

namespace ElassandraTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuracoes.Servidor = "192.168.100.46";
            Configuracoes.ServidorElasticSearch = "http://192.168.100.46:9200";
            ConfiguracoesSqlServer.StringConexao = "Server=192.168.100.46;Database=Teste;User ID=sa;Password=!Q@W#E4r;Trusted_Connection=False; MultipleActiveResultSets=true";
            var services = new ServiceCollection()
                .AddScoped<CassandraDBContext, CassandraDBContext>()
                .AddScoped<ElasticsearchDBContext, ElasticsearchDBContext>()
                .AddScoped<SqlServerContext, SqlServerContext>()
                .AddTransient<IPaleteCarregamentoRepositorio, PaleteCarregamentoRepositorio>()
                .AddTransient<IPaleteCarregamentoSalvar, PaleteCarregamentoSalvar>()
                .AddTransient<IPaleteCarregamentoBuscar, PaleteCarregamentoBuscar>()
                .AddTransient<Testar, Testar>();
                
            var serviceProvider = services.BuildServiceProvider();
            var testar = serviceProvider.GetService<Testar>();
            
            Console.WriteLine("Hello World!");


            testar.Executar();

            Console.ReadKey();
        }
    }
}