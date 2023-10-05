using MongoDB.Bson.Serialization.Attributes;

namespace testRest.Models
{
        public class Cobertura
        {
            [BsonElement("Nombre")]
            public string Nombre { get; set; }
        }
}
