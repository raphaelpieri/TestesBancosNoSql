using System.Collections.Generic;

namespace Domain.PaletesCarregamento
{
    public interface IPaleteCarregamentoBuscar
    {
        IList<PaleteCarregamentoRetorno> BuscarTodos();
    }
}