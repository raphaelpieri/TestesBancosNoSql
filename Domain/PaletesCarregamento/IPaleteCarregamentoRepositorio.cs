using System.Collections.Generic;

namespace Domain.PaletesCarregamento
{
    public interface IPaleteCarregamentoRepositorio
    {
        void Salvar(PaleteCarregamento paletesCarregamento);
        IList<PaleteCarregamento> BuscarTodos();
    }
}