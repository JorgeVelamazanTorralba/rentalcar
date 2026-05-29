using System.Text.Json.Serialization;
using MongoDB.Bson;

namespace GtMotive.Estimate.Microservice.Domain.Models.Entities
{
    /// <summary>
    /// BaseEntity.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets internal MongoDb id.
        /// </summary>
        [JsonPropertyName("_id")]
        public ObjectId Id { get; set; }
    }
}
