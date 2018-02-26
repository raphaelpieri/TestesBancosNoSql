using System;
using Cassandra;
using Cassandra.Mapping;

namespace Infra.Elassandra
{
    public class CassandraDBContext
    {
        private readonly Cluster _cluster;

        public CassandraDBContext()
        {
            try
            {
                _cluster = Cluster.Builder().AddContactPoint(Configuracoes.Servidor).Build();
                MappingConfiguration.Global.Define(new PaleteCarregamentoMapeamento());
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }


        public ISession Session => _cluster.Connect();
        
        public void Dispose()
        {
            _cluster.Dispose();
        }
    }
}