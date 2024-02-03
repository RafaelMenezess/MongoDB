using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace MongoDB
{
    internal class alterandoDocClasse
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
            }
            Console.WriteLine("");
            Console.WriteLine("Fim da lista");
            Console.WriteLine("");
            Console.WriteLine("");

            var construtorAlteracao = Builders<Livro>.Update;
            var condicaoAlteracao = construtorAlteracao.Set(x => x.Ano, 2001);
            conexaoBiblioteca.Livros.UpdateOne(condicao, condicaoAlteracao);
            Console.WriteLine("Registro Alterado");
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

            Console.WriteLine("Listar e alterar o livro George R R Martin");
            contrutor = Builders<Livro>.Filter;
            condicao = contrutor.Eq(x => x.Autor, "George R R Martin");

            listaLivros = conexaoBiblioteca.Livros.Find(condicao).ToList();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }
            Console.WriteLine("");
            Console.WriteLine("Fim da lista");
            Console.WriteLine("");
            Console.WriteLine("");

            construtorAlteracao = Builders<Livro>.Update;
            condicaoAlteracao = construtorAlteracao.Set(x => x.Autor, "George R Martin");
            conexaoBiblioteca.Livros.UpdateMany(condicao, condicaoAlteracao);
            Console.WriteLine("Registro Alterado");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.ReadLine();
        }
    }
}
