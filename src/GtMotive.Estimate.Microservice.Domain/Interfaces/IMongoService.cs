using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// IMongoService.
    /// </summary>
    public interface IMongoService
    {
        /// <summary>
        /// Gets the collection by name.
        /// </summary>
        /// <typeparam name="T">TDocument.</typeparam>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>IMongoCollection.</returns>
        Task<IMongoCollection<T>> GetCollectionAsync<T>(CancellationToken cancellationToken);
    }
}
