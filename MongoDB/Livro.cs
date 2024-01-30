﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MongoDB
{
    public class Livro
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public List<string> Assunto { get; set; }
    }

    public class valoresLivro
    {
        public static Livro incluiValoresLivro(string Titulo, string Autor, int Ano, int Paginas, string assuntos)
        {
            Livro livro = new Livro();
            livro.Titulo = Titulo;
            livro.Autor = Autor;
            livro.Ano = Ano;
            livro.Paginas = Paginas;
            string[] vetAssunto = assuntos.Split(',');
            List<string> vetAssunto2 = new List<string>();
            for (int i = 0; i < vetAssunto.Length; i++)
            {
                vetAssunto2.Add(vetAssunto[i].Trim());
            }
            livro.Assunto = vetAssunto2;

            return livro;
        }
    }
}
