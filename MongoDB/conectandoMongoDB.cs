using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDB
{
    class conectandoMongoDB
    {
        public const string STRING_DE_CONEXAO = "mongodb://localhost:27017";
        public const string NOME_DA_BASE = "Biblioteca";
        public const string NOME_DA_COLECAO = "Livros";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static conectandoMongoDB()
        {
            _client = new MongoClient(STRING_DE_CONEXAO);
            _database = _client.GetDatabase(NOME_DA_BASE);
        }

        public IMongoClient Client
        {
            get { return _client; }
        }
        public IMongoCollection<Livro> Livros
        {
            get { return _database.GetCollection<Livro>(NOME_DA_COLECAO); }
        }

    }
}
