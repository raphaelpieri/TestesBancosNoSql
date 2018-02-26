using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Domain.PaletesCarregamento;

namespace ElassandraTeste
{
    public class Testar
    {
        private readonly IPaleteCarregamentoSalvar _salvar;
        private readonly IPaleteCarregamentoBuscar _buscar;
        private readonly ICollection<Retorno> _retorno;
        

        public Testar(IPaleteCarregamentoSalvar salvar, IPaleteCarregamentoBuscar buscar)
        {
            _salvar = salvar;
            _buscar = buscar;
            _retorno = new List<Retorno>();
        }

        public void Executar()
        {
            Console.Clear();
            var interacoes = 200000;
            var documentos = new List<Guid>();
            var relizarMonstragem = 10000;

            var st = new Stopwatch();
            
            st.Start();


            for (var i = 1; i <= interacoes; i++)
            {
                if (i % relizarMonstragem == 0)
                {
                    var mensagem =
                        $"Já foram {i} interacoes: {st.Elapsed:g} - (Tempo medio por request: {st.ElapsedMilliseconds / i} ms";
                    Console.WriteLine(mensagem);
                    NovoRetorno(Tipo.ESCRITA, i, mensagem);
                }

                var novoPalete = _salvar.Salvar(new PaleteCarregamentoRequisicao()
                {
                    Descricao = $"Inserido o palete da posicao: {i}",
                    NomeUsuario = $"{i} Usuario",
                    NumeroDoDocumento = Guid.NewGuid().ToString().Substring(1, 4),
                    Pontuacao = i
                });
                documentos.Add(novoPalete);
            }
            st.Stop();
            Console.WriteLine($"### CONCLUIDO ESCRITA: {st.Elapsed:g}");

            var consulta = 1;
            st.Reset();
            st.Start();
            documentos.ForEach(documento =>
            {
                if (consulta % relizarMonstragem == 0)
                {
                    var mensagem =
                        $"Já foram {consulta} interacoes: {st.Elapsed:g} - (Tempo medio por request: {st.ElapsedMilliseconds / consulta} ms";
                    Console.WriteLine(mensagem);
                    NovoRetorno(Tipo.CONSULTA, consulta, mensagem);
                }

                var palete = _buscar.Buscar(documento);
                consulta++;
            });
            st.Stop();
            Arquivo.Gravar(_retorno);
            Console.WriteLine($"### CONCLUIDO Consulta: {st.Elapsed:g}");
        }

        private void NovoRetorno(Tipo tipo, int posicao, string mensagem)
        {
            _retorno.Add(new Retorno(tipo, posicao, mensagem));
        }
    }
}