using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    /// <summary>
    /// ReleaseRequest.
    /// </summary>
    public class ReleaseVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets vehicle's license plate.
        /// </summary>
        [JsonPropertyName("licensePlate")]
        [Required]
        public string LicensePlate { get; set; }
    }
}
