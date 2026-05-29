using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoService(IOptions<MongoDbSettings> options) : IMongoService
    {
        private bool _collectionCreated;

        public MongoClient MongoClient { get; } = new MongoClient(options.Value.ConnectionString);

        private IMongoDatabase Database => MongoClient.GetDatabase(options.Value.MongoDbDatabaseName);

        public async Task<IMongoCollection<T>> GetCollectionAsync<T>(CancellationToken cancellationToken)
        {
            if (!_collectionCreated)
            {
                if (!await CheckIfCollectionExists(cancellationToken))
                {
                    await Database.CreateCollectionAsync(options.Value.CollectionName, cancellationToken: cancellationToken);
                }

                _collectionCreated = true;
            }

            return Database.GetCollection<T>(options.Value.CollectionName);
        }

        private async Task<bool> CheckIfCollectionExists(CancellationToken cancellationToken)
        {
            // filter by collection name
            var collections = await Database.ListCollectionsAsync(new ListCollectionsOptions { Filter = new BsonDocument("name", options.Value.CollectionName) }, cancellationToken: cancellationToken);

            // check for existence
            return await collections.AnyAsync(cancellationToken);
        }
    }
}
