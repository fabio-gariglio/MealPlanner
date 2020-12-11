using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System.Security.Authentication;
using Microsoft.Extensions.Configuration;

namespace WebApp.IoC
{
    public static class MongoDbExtensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["mongodb:connectionString"];
            var databaseName = configuration["mongodb:database"];

            var settings = MongoClientSettings.FromConnectionString(connectionString);
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

            var client = new MongoClient(settings);
            var database = client.GetDatabase(databaseName);

            services.AddSingleton(database);

            return services;
        }
    }
}
