using System;

namespace Domain.PaletesCarregamento
{
    public class PaleteCarregamentoSalvar : IPaleteCarregamentoSalvar
    {
        public PaleteCarregamentoSalvar(IPaleteCarregamentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        private readonly IPaleteCarregamentoRepositorio _repositorio;
        public Guid Salvar(PaleteCarregamentoRequisicao requisicao)
        {
            var palete = new PaleteCarregamento(requisicao.NumeroDoDocumento, requisicao.NomeUsuario, requisicao.Descricao, requisicao.Pontuacao);
            _repositorio.Salvar(palete);
            return palete.Id;
        }

        public string Salvar2(PaleteCarregamentoRequisicao requisicao)
        {
            var palete = new PaleteCarregamento(requisicao.NumeroDoDocumento, requisicao.NomeUsuario, requisicao.Descricao, requisicao.Pontuacao);
            _repositorio.Salvar(palete);
            return palete.NumeroDocumento;
        }
    }
}