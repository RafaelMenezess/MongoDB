using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB
{
    public class buscaAeroportos
    {
        static void Main(string[] args)
        {
            //acesso atraves da classe de conexao
            var conexaoAeroporto = new conectandoMongoDBGeo();
            var ponto = new GeoJson2DGeographicCoordinates(-118.325258, 34.103212);
            var localizacao = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(ponto);

            var construtor = Builders<Aeroporto>.Filter;
            var condicao = construtor.NearSphere(x => x.Loc, localizacao, 100000);
            var listaAeroportos = conexaoAeroporto.Airports.Find(condicao).ToList();
            foreach (var aeroporto in listaAeroportos)
            {
                Console.WriteLine(aeroporto.ToJson<Aeroporto>());
            }

            Console.ReadLine();
        }
    }
}
