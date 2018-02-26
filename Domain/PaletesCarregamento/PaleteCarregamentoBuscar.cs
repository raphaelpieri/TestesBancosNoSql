using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.PaletesCarregamento
{
    public class PaleteCarregamentoBuscar : IPaleteCarregamentoBuscar
    {
        public PaleteCarregamentoBuscar(IPaleteCarregamentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        private readonly IPaleteCarregamentoRepositorio _repositorio;
        
        public IList<PaleteCarregamentoRetorno> BuscarTodos()
        {
            return _repositorio.BuscarTodos().Select(x => new PaleteCarregamentoRetorno(x.Id.ToString(), x.NumeroDocumento,
                x.NomeUsuario, x.Tipo, x.Descricao, x.Status, x.Pontuacao)).ToList();
        }

        public PaleteCarregamentoRetorno Buscar(Guid id)
        {
            var busca = _repositorio.Buscar(id);
            return new PaleteCarregamentoRetorno(busca.Id.ToString(), busca.NumeroDocumento, busca.NomeUsuario, busca.Tipo, 
                busca.Descricao, busca.Status, busca.Pontuacao);
        }

        public PaleteCarregamentoRetorno BuscarElasticSearch(Guid id)
        {
            var busca = _repositorio.BuscarElasticSearch(id);
            return new PaleteCarregamentoRetorno(busca.Id.ToString(), busca.NumeroDocumento, busca.NomeUsuario, busca.Tipo, 
                busca.Descricao, busca.Status, busca.Pontuacao);
        }

        public PaleteCarregamentoRetorno Buscar(string numeroDoDocumento)
        {
            var busca = _repositorio.Buscar(numeroDoDocumento);
            return new PaleteCarregamentoRetorno(busca.Id.ToString(), busca.NumeroDocumento, busca.NomeUsuario, busca.Tipo, 
                busca.Descricao, busca.Status, busca.Pontuacao);
        }
    }
}