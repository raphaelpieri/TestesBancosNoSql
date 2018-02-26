using System;
using System.Collections.Generic;
using System.Linq;
using Domain.PaletesCarregamento;

namespace Infra.Cassandra
{
    public class PaleteCarregamentoRepositorio : IPaleteCarregamentoRepositorio
    {
        public PaleteCarregamentoRepositorio(CassandraDbContext context)
        {
            _context = context;
        }

        private readonly CassandraDbContext _context;
        
        public void Salvar(PaleteCarregamento paletesCarregamento)
        {
            var execute = $"INSERT INTO paletescarregamento(\"_id\", numeroDoDocumento, nomeUsuario, descricao, pontuacao," +
                          $"tipo, status) VALUES ({paletesCarregamento.Id},'{paletesCarregamento.NumeroDocumento}', " +
                          $"'{paletesCarregamento.NomeUsuario}', '{paletesCarregamento.Descricao}', " +
                          $"{paletesCarregamento.Pontuacao}, {paletesCarregamento.Tipo}, {paletesCarregamento.Status})";

            _context.Session.Execute(execute);
        }

        public IList<PaleteCarregamento> BuscarTodos()
        {
            var execute = "SELECT \"_id\", numeroDocumento, nomeUsuario, tipo, descricao, status, pontuacao" +
                          $" FROM paletescarregamento";

            var result = _context.Session.Execute(execute).ToList();
            return result.Select(x => new PaleteCarregamento(
                Guid.Parse(x["\"_id\""].ToString()),
                x["numerodocumento"].ToString(),
                x["nomeusuario"].ToString(),
                int.Parse(x["tipo"].ToString()),
                x["descricao"].ToString(),
                bool.Parse(x["status"].ToString()),
                int.Parse(x["pontuacao"].ToString()))).ToList();
        }

        public PaleteCarregamento Buscar(Guid id)
        {
            throw new NotImplementedException();
        }

        public PaleteCarregamento BuscarElasticSearch(Guid id)
        {
            throw new NotImplementedException();
        }

        public PaleteCarregamento Buscar(string nome)
        {
            throw new NotImplementedException();
        }
    }
}