using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB
{
    public class manipulandoClasses
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
            livro.Titulo = "Sob a redonda";
            livro.Autor = "Stepahn King";
            livro.Ano = 2012;
            livro.Paginas = 679;

            List<string> listaAssunto = new List<string>();
            listaAssunto.Add("Ficção Científica");
            listaAssunto.Add("Terror");
            listaAssunto.Add("Ação");
            livro.Assunto = listaAssunto;

            //acesso MongoDb
            var stringConexao = "mongodb://localhost:27017";
            IMongoClient cliente = new MongoClient(stringConexao);

            //acesso ao banco de dados
            IMongoDatabase bancoDados = cliente.GetDatabase("Biblioteca");

            //acesso a coleção
            IMongoCollection<Livro> colecao = bancoDados.GetCollection<Livro>("Livros");

            //incluindo documento
            await colecao.InsertOneAsync(livro);

            Console.WriteLine("Documento Incluido");

            Console.ReadLine();
        }
    }
}
