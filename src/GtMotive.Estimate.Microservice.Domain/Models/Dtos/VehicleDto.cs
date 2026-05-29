using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GtMotive.Estimate.Microservice.Domain.Models.Dtos
{
    /// <summary>
    /// Vehicle dto.
    /// </summary>
    public class VehicleDto
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
        [RegularExpression("^(\\d{4}\\/\\d{2}\\/\\d{2})|(\\d{4}-\\d{2}-\\d{2})$", ErrorMessage = "AssemblyDate must match with one of those formats (yyyy/MM/dd or yyyy-MM-dd)")]
        public string AssemblyDate { get; set; }
    }
}
