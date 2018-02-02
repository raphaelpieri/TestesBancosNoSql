using System;

namespace Domain.PaletesCarregamento
{
    public class PaleteCarregamento
    {
        protected PaleteCarregamento()
        {
        }

        public PaleteCarregamento(string numeroDocumento, string nomeUsuario, string descricao, int pontuacao) : this(
            Guid.NewGuid(), numeroDocumento, nomeUsuario, 1, descricao, true, pontuacao)
        {
            
        }
        
        public PaleteCarregamento(Guid id, string numeroDocumento, string nomeUsuario, int tipo, string descricao, bool status, int pontuacao)
        {
            Id = id;
            NumeroDocumento = numeroDocumento;
            NomeUsuario = nomeUsuario;
            Tipo = tipo;
            Descricao = descricao;
            Status = status;
            Pontuacao = pontuacao;
        }

        public Guid Id { get; private set; }
        public string NumeroDocumento { get; private set; }
        public string NomeUsuario { get; private set; }
        public int Tipo { get; private set; }
        public string Descricao { get; private set; }
        public bool Status { get; private set; }
        public int Pontuacao { get; private set; }
    }
}