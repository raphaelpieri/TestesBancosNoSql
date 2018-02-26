using System;
using System.Collections.Generic;

namespace Domain.PaletesCarregamento
{
    public interface IPaleteCarregamentoBuscar
    {
        IList<PaleteCarregamentoRetorno> BuscarTodos();
        PaleteCarregamentoRetorno Buscar(Guid id);
        PaleteCarregamentoRetorno BuscarElasticSearch(Guid id);
        PaleteCarregamentoRetorno Buscar(string numeroDoDocumento);
    }
}