using System;

namespace ElassandraTeste
{
    public class Retorno
    {
        public Retorno(Tipo tipo, int numeroDeTransacao, string mensagem)
        {
            Tipo = tipo;
            NumeroDeTransacao = numeroDeTransacao;
            Mensagem = mensagem;
            
        }

        public Tipo Tipo { get; private set; }
        public string TipoString => Enum.GetName(typeof(Tipo), Tipo);
        public int NumeroDeTransacao { get; private set; }
        public string Mensagem { get; private set; }
    }
}