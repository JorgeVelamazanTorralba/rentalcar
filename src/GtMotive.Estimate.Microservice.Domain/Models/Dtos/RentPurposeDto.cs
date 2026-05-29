using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GtMotive.Estimate.Microservice.Domain.Models.Dtos
{
    /// <summary>
    /// RentPurpose dto.
    /// </summary>
    public class RentPurposeDto
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
