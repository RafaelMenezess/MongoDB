using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace MongoDB
{
    public class usandoValoresLivros
    {
        static void Main(string[] args)
        {
            //acesso atraves da classe de conexao
            var conexaoBiblioteca = new conectandoMongoDB();

            Livro livro = new Livro();
            livro = valoresLivro.incluiValoresLivro("O Senhor dos Aneis", "J R R Token", 1948, 1956, "Fantasia, Ação");

            //incluindo documento
            conexaoBiblioteca.Livros.InsertOne(livro);

            Console.WriteLine("Documento Incluido");

            Console.ReadLine();
        }
    }
}
