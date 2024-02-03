using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace MongoDB
{
    public class alterandoDoc
    {
        static void Main(string[] args)
        {
            //acesso atraves da classe de conexao
            var conexaoBiblioteca = new conectandoMongoDB();


            Console.WriteLine("Listar e alterar o livro Stars Wars");
            var contrutor = Builders<Livro>.Filter;
            var condicao = contrutor.Eq(x => x.Titulo, "Stars Wars");

            var listaLivros = conexaoBiblioteca.Livros.Find(condicao).ToList();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
                doc.Ano = 2000;
                doc.Paginas = 900;
                conexaoBiblioteca.Livros.ReplaceOne(condicao, doc);
            }
            Console.WriteLine("");
            Console.WriteLine("Fim da lista");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listar o livro Stars Wars");

            listaLivros = conexaoBiblioteca.Livros.Find(condicao).ToList();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("");
            Console.WriteLine("Fim da lista");
            Console.WriteLine("");
            Console.WriteLine("");


            Console.ReadLine();
        }
    }
}
