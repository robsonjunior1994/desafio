using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //Type diz se é CD/DVD/LIVRO
        [BsonElement("Type")]
        public string Type { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("State")]
        //State representa Disponivel ou emprestado.
        public string State { get; set; }

        [BsonElement("Year")]
        public string Year { get; set; }

        [BsonElement("Genres")]
        public string Genres { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("BorrowedTo")]
        public string BorrowedTo { get; set; }


        public static string TratandoFiltroDeStatus(string status)
        {
            status = status.ToLower();

            if (status == "disponível")
            {
                status = "disponivel";
            }
            if (status == "indisponível")
            {
                status = "indisponivel";
            }

            return status;
        }

        public static bool VerificarSeStatusTemOsValoresValidos(string status)
        {
            if(status == "indisponivel" || status == "disponivel")
            {
                return true;
            }
            return false;
        }

    }
}
