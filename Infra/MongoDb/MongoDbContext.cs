using System;
using System.Security.Authentication;
using Domain.PaletesCarregamento;
using MongoDB.Driver;

namespace Infra.MongoDb
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(Configuracoes.ConnectionString));
                if (Configuracoes.IsSSl)
                    settings.SslSettings = new SslSettings {EnabledSslProtocols = SslProtocols.Tls};
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(Configuracoes.DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        public IMongoCollection<PaleteCarregamento> PaletesCarregamento =>
            _database.GetCollection<PaleteCarregamento>("PaletesCarregamento");

    }
}