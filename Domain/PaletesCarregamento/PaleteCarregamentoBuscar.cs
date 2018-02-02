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
    }
}