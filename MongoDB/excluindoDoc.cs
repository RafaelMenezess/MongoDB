using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace MongoDB
{
    public class excluindoDoc
    {
        static void Main(string[] args)
        {
            //acesso atraves da classe de conexao
            var conexaoBiblioteca = new conectandoMongoDB();

            Console.WriteLine("Bucas os Livros George R Martin ");
            var contrutor = Builders<Livro>.Filter;
            var condicao = contrutor.Eq(x => x.Autor, "George R Martin");

            var listaLivros = conexaoBiblioteca.Livros.Find(condicao).ToList();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }
            Console.WriteLine("");
            Console.WriteLine("Fim da lista");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Excluindo os livros");
            conexaoBiblioteca.Livros.DeleteMany(condicao);

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
