using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Excecoes
{
    public class LeitorDeArquivo : IDisposable
    {
        public string Arquivo { get; }

        public LeitorDeArquivo(string arquivo)
        {
            Arquivo = arquivo;

            // throw new FileNotFoundException();

            Console.WriteLine("Abrindo arquivo: " + arquivo);
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha. . .");

            // Para simular as exceções (por exemplo arquivo corrompido) que podem ocorrer dentro do método LerProximaLinha() foi lançada a IOException.
            throw new IOException();

            return "Linha do arquivo";
        }

        // Caso no using seja verificada que a referência não é nula, o método Dispose() é chamado, e por causa dele que se torna necessário implementar a interface IDisposable na classe LeitorDeArquivo.
        // Seguindo a convenção do .NET o Dispose() é o método que deve liberar os recursos, por isso ao invés de utilizar o método Fechar(), o "Fechando arquivo" ficou dentro do Dispose().
        public void Dispose()
        {
            Console.WriteLine("Fechando arquivo.");
        }
    }
}
