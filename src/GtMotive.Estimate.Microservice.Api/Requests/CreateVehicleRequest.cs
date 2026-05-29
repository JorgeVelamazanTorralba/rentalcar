using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    /// <summary>
    /// CreateVehicleRequest.
    /// </summary>
    public class CreateVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets vehicle's license plate.
        /// </summary>
        [JsonPropertyName("licensePlate")]
        [Required]
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets vehicle's model.
        /// </summary>
        [JsonPropertyName("model")]
        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets vehicle's description.
        /// </summary>
        [JsonPropertyName("description")]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets vehicle's assembly date.
        /// </summary>
        [JsonPropertyName("assemblyDate")]
        [Required]
        public DateTime AssemblyDate { get; set; } = DateTime.Now;
    }
}
