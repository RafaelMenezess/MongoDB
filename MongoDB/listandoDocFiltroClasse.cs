using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace MongoDB
{
    public class listandoDocFiltroClasse
    {
        static void Main(string[] args)
        {
            //acesso atraves da classe de conexao
            var conexaoBiblioteca = new conectandoMongoDB();

            Console.WriteLine("Listando Documentos Machado de Assis");
            var filtro = new BsonDocument
            {
                {"Autor", "Machado de Assis" }
            };
            var listaLivros = conexaoBiblioteca.Livros.Find(filtro).ToList();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }
            Console.WriteLine("Fim da lista");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando Documentos Machado de Assis - Classe");
            var contrutor = Builders<Livro>.Filter;
            var condicao = contrutor.Eq(x => x.Autor, "Machado de Assis");

            listaLivros = conexaoBiblioteca.Livros.Find(condicao).ToList();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }
            Console.WriteLine("Fim da lista");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando Documentos Ano publicação maior ou igual 1999");
            contrutor = Builders<Livro>.Filter;
            condicao = contrutor.Gte(x => x.Ano, 1999);

            listaLivros = conexaoBiblioteca.Livros.Find(condicao).ToList();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }
            Console.WriteLine("Fim da lista");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando Documentos Ano publicação a partir 1999 e que tenha mais de 300 páginas");
            contrutor = Builders<Livro>.Filter;
            condicao = contrutor.Gte(x => x.Ano, 1999) & contrutor.Gte(x => x.Paginas, 300);

            listaLivros = conexaoBiblioteca.Livros.Find(condicao).ToList();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }
            Console.WriteLine("Fim da lista");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando Documentos somente de ficção científica");
            contrutor = Builders<Livro>.Filter;
            condicao = contrutor.AnyEq(x => x.Assunto, "Ficção Científica");

            listaLivros = conexaoBiblioteca.Livros.Find(condicao).ToList();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }
            Console.WriteLine("Fim da lista");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.ReadLine();
        }
    }
}
