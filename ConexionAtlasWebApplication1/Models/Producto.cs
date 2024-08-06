using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Zapateria.Models
{
    public class Producto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nombre")]
        public string Nombre { get; set; }

        [BsonElement("Precio")]
        public decimal Precio { get; set; }

        [BsonElement("Cantidad")]
        public int Cantidad { get; set; }
    }
}
