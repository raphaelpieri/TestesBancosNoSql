using System;
using System.Collections.Generic;
using System.Linq;
using Cassandra.Data.Linq;
using Cassandra.Mapping;
using Domain.PaletesCarregamento;

namespace Infra.Elassandra
{
    public class PaleteCarregamentoRepositorio : IPaleteCarregamentoRepositorio
    {
        private readonly IMapper _mapper;
        private readonly CassandraDBContext _context;
        private readonly ElasticsearchDBContext _contextElasticSearch;

        public PaleteCarregamentoRepositorio(CassandraDBContext context, ElasticsearchDBContext contextElasticSearch)
        {
            _context = context;
            _contextElasticSearch = contextElasticSearch;
            _mapper = new Mapper(_context.Session);
        }

        public void Salvar(PaleteCarregamento paletesCarregamento) 
        {
            _mapper.Insert(paletesCarregamento);

        }

        public IList<PaleteCarregamento> BuscarTodos()
        {
            return _mapper.Fetch<PaleteCarregamento>().ToList();
        }

        public PaleteCarregamento Buscar(Guid id)
        {
            var paletes = new Table<PaleteCarregamento>(_context.Session);
            return paletes.FirstOrDefault(x => x.Id == id).Execute();
        }

        public PaleteCarregamento BuscarElasticSearch(Guid id)
        {
            var retorno = _contextElasticSearch.Cliente.Search<PaleteCarregamento>(s => s
                .Index("teste2")
                .Type("palete")
                .Query(q => q.Match(m => m.Field(f => f.Id).Query(id.ToString()))));

            return retorno.Documents.FirstOrDefault();
        }

        public PaleteCarregamento Buscar(string nome)
        {
            var retorno = _contextElasticSearch.Cliente.Search<PaleteCarregamento>(s => s
                .Index("teste2")
                .Type("palete")
                .Query(q => q.Match(m => m.Field(f => f.NumeroDocumento).Query(nome))));

            return retorno.Documents.FirstOrDefault();
        }
    }
}