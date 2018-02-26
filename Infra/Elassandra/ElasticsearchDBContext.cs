using System;
using Elasticsearch.Net;
using Nest;

namespace Infra.Elassandra
{
    public class ElasticsearchDBContext
    {
        public ElasticsearchDBContext()
        {
            var nodes = new Uri[]
            {
                new Uri(Configuracoes.ServidorElasticSearch)
            };

            var connectionPoll = new StaticConnectionPool(nodes);
            var connectionSetting = new ConnectionSettings(connectionPoll);
            Cliente = new ElasticClient(connectionSetting);
        }

        public ElasticClient Cliente { get; private set; }
    }
}