using System;

namespace Domain.PaletesCarregamento
{
    public class PaleteCarregamento
    {
        public PaleteCarregamento()
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

        public Guid Id { get;  set; }
        public string NumeroDocumento { get;  set; }
        public string NomeUsuario { get;  set; }
        public int Tipo { get;  set; }
        public string Descricao { get;  set; }
        public bool Status { get;  set; }
        public int Pontuacao { get;  set; }
    }
}