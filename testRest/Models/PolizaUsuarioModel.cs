using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace testRest.Models
{
    public class PolizaUsuarioModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("nombre_cliente")]
        public string NombreCliente { get; set; }
        [BsonElement("identificacion_cliente")]
        public string IdentificacionCliente { get; set; }
        [BsonElement("fecha_nacimiento_cliente")]
        public DateTime FechaNacimientoCliente { get; set; }
        [BsonElement("ciudad_residencia")]
        public string CiudadResidenciaCliente { get; set; }
        [BsonElement("direccion_residencia")]
        public string DireccionResidenciaCliente { get; set; }
        [BsonElement("placa_automotor")]
        public string PlacaAutomotor { get; set; }
        [BsonElement("modelo_automotor")]
        public string ModeloAutomotor { get; set; }
        [BsonElement("tiene_inspeccion")]
        public bool VehiculoTieneInspeccion { get; set; }
        [BsonElement("polizas")]
        public List<string> poliza { get; set; }
    }
}
