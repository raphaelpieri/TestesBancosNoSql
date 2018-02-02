using System;
using Cassandra;

namespace Infra.Cassandra
{
    public class CassandraDbContext : IDisposable
    {
        private readonly Cluster _cluster;

        public CassandraDbContext()
        {
            try
            {
                _cluster = Cluster.Builder().AddContactPoint(Configuracores.Servidor).Build();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }


        public ISession Session => _cluster.Connect(Configuracores.Cluster);
        
        public void Dispose()
        {
            _cluster.Dispose();
        }
    }
}