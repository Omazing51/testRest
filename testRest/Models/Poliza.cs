using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using ThirdParty.Json.LitJson;

namespace testRest.Models
{
    public class Poliza
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("numero_poliza")]
        public string numeroPoliza { get; set; }
        [BsonElement("nombre_plan_poliza")]
        public string nombrePlanPoliza { get; set; }
        [BsonElement("valor_max_cubierto")]
        public decimal valorMaximoCubierto { get; set; }
        [BsonElement("fecha_inicio_poliza")]
        public DateTime fechaInicioPoliza { get; set; }
        [BsonElement("fecha_fin_poliza")]
        public DateTime fechaFinPoliza { get; set; }
        [BsonElement("Coberturas")]
        public List<string> cobertura { get; set; }
    }
}
