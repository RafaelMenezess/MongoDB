using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB
{
    public class ManipulandoClassesExternas
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine();
            Console.WriteLine("Presione Enter");
            Console.ReadLine();
        }
        static async Task MainAsync(string[] args)
        {
            Livro livro = new Livro();
            livro.Titulo = "Stars Wars";
            livro.Autor = "Timothy Zahn";
            livro.Ano = 2010;
            livro.Paginas = 245;

            List<string> listaAssunto = new List<string>();
            listaAssunto.Add("Ficção Científica"); ;
            listaAssunto.Add("Ação");
            livro.Assunto = listaAssunto;

            //acesso atraves da classe de conexao
            var conexaoBiblioteca = new conectandoMongoDB();           

            //incluindo documento
            await conexaoBiblioteca.Livros.InsertOneAsync(livro);

            Console.WriteLine("Documento Incluido");

            Console.ReadLine();
        }
    }
}
