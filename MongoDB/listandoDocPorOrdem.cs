using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace MongoDB
{
    public class listandoDocPorOrdem
    {
        static void Main(string[] args)
        {
            //acesso atraves da classe de conexao
            var conexaoBiblioteca = new conectandoMongoDB();


            Console.WriteLine("Listando Documentos Machado de Assis mais de 100 páiginas");
            var contrutor = Builders<Livro>.Filter;
            var condicao = contrutor.Gt(x => x.Paginas, 100);

            var listaLivros = conexaoBiblioteca.Livros.Find(condicao).SortBy(x => x.Titulo).Limit(5).ToList();
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
