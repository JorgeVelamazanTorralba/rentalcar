using System;
using System.Text.Json.Serialization;

namespace GtMotive.Estimate.Microservice.Domain.Models.Dtos
{
    /// <summary>
    /// Vehicle entity.
    /// </summary>
    public class AvailableVehicleDto
    {
        /// <summary>
        /// Gets or sets vehicle's license plate.
        /// </summary>
        [JsonPropertyName("LicensePlate")]
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets vehicle's model.
        /// </summary>
        [JsonPropertyName("Model")]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets vehicle's description.
        /// </summary>
        [JsonPropertyName("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets vehicle's assembly date.
        /// </summary>
        [JsonPropertyName("AssemblyDate")]
        public DateTime AssemblyDate { get; set; }
    }
}
