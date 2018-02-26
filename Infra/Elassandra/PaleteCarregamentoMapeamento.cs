using System.Runtime.InteropServices.ComTypes;
using Cassandra.Mapping;
using Domain.PaletesCarregamento;

namespace Infra.Elassandra
{
    public class PaleteCarregamentoMapeamento : Mappings
    {
        public PaleteCarregamentoMapeamento()
        {
            For<PaleteCarregamento>()
                .KeyspaceName("teste2")
                .TableName("palete")
                .PartitionKey(p => p.Id)
                .Column(p => p.Id, cm => cm.WithName("id"))
                .Column(p => p.NumeroDocumento, cm => cm.WithName("numerodocumento"))
                .Column(p => p.NomeUsuario, cm => cm.WithName("nomeusuario"))
                .Column(p => p.Descricao, cm => cm.WithName("descricao"))
                .Column(p => p.Pontuacao, cm => cm.WithName("pontuacao"))
                .Column(p => p.Status, cm => cm.WithName("status"))
                .Column(p => p.Tipo, cm => cm.WithName("tipo"));
        }
    }
}