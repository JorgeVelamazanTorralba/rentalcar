using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    /// <summary>
    /// RentalRequest.
    /// </summary>
    public class RentVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets vehicle's license plate.
        /// </summary>
        [JsonPropertyName("licensePlate")]
        [Required]
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets customer pin.
        /// </summary>
        [JsonPropertyName("customerPin")]
        [Required]
        public string CustomerPin { get; set; }
    }
}
