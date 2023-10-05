using MongoDB.Driver;
using testRest.Helpers;
using testRest.Models;

namespace testRest.Services
{
    public class PolizaService
    {
        private IMongoCollection<Poliza> _poliza;
        public PolizaService(IPolizaSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _poliza = database.GetCollection<Poliza>("poliza");
        }

        public List<Poliza> Get()
        {
            return _poliza.Find(x => true).ToList();
        }

        public Poliza Create(Poliza poliza)
        {
            _poliza.InsertOne(poliza);

            return poliza;
        }

    }
}
