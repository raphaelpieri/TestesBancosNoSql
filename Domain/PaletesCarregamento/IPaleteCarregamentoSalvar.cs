using System;

namespace Domain.PaletesCarregamento
{
    public interface IPaleteCarregamentoSalvar
    {
        Guid Salvar(PaleteCarregamentoRequisicao requisicao);
        string Salvar2(PaleteCarregamentoRequisicao requisicao);
    }
}