using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace MongoDB
{
    public class listandoDocFiltroBson
    {
        static void Main(string[] args)
        {
            //acesso atraves da classe de conexao
            var conexaoBiblioteca = new conectandoMongoDB();

            Console.WriteLine("Listando Documentos");
            var filtro = new BsonDocument();
            var listaLivros = conexaoBiblioteca.Livros.Find(filtro).ToList();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Listando Documentos Machado de Assis");
            filtro = new BsonDocument
            {
                {"Autor", "Machado de Assis" }
            };
            listaLivros = conexaoBiblioteca.Livros.Find(filtro).ToList();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.ReadLine();
        }
    }
}
