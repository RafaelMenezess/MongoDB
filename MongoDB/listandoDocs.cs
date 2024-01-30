using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MongoDB
{
    public class listandoDocs
    {
        static void Main(string[] args)
        {
            //acesso atraves da classe de conexao
            var conexaoBiblioteca = new conectandoMongoDB();

            Console.WriteLine("Listando Documentos");
            var listaLivros = conexaoBiblioteca.Livros.Find(new BsonDocument()).ToList();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.ReadLine();
        }
    }
}
