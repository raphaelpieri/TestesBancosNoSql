using Domain.PaletesCarregamento;
using Microsoft.EntityFrameworkCore;

namespace Infra.SqlServer
{
    public class SqlServerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfiguracoesSqlServer.StringConexao);
        }

        public DbSet<PaleteCarregamento> Paletes { get; set; }
    }
}