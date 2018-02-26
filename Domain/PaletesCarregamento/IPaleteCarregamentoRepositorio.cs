using System;
using System.Collections.Generic;

namespace Domain.PaletesCarregamento
{
    public interface IPaleteCarregamentoRepositorio
    {
        void Salvar(PaleteCarregamento paletesCarregamento);
        IList<PaleteCarregamento> BuscarTodos();
        PaleteCarregamento Buscar(Guid id);
        PaleteCarregamento BuscarElasticSearch(Guid id);
        PaleteCarregamento Buscar(string nome);
    }
}