using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ElassandraTeste
{
    public class Arquivo
    {
        public static void Gravar(ICollection<Retorno> dados)
        {
            var nomeDoArquivo = "retorno.txt";
            if(File.Exists(nomeDoArquivo))
                File.Delete(nomeDoArquivo);

            try
            {
                using (var arquivo = new StreamWriter(nomeDoArquivo))
                {
                    var listaEscrita = dados.Where(x => x.Tipo == Tipo.ESCRITA).OrderBy(x => x.NumeroDeTransacao)
                        .ToList();
                    arquivo.WriteLine("INICIO ESCRITA");
                    listaEscrita.ForEach(item => arquivo.WriteLine(item.Mensagem));
                    arquivo.WriteLine("FIM ESCRITA");
                    
                    arquivo.WriteLine("");
                    

                    listaEscrita = dados.Where(x => x.Tipo == Tipo.CONSULTA).OrderBy(x => x.NumeroDeTransacao)
                        .ToList();
                    arquivo.WriteLine("INICIO CONSULTA");
                    listaEscrita.ForEach(item => arquivo.WriteLine(item.Mensagem));
                    arquivo.WriteLine("FIM CONSULTA");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
                
            }
        }
    }
}