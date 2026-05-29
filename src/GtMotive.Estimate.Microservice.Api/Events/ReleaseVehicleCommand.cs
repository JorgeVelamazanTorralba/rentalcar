using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Events
{
    /// <summary>
    /// ReleaseVehicle event.
    /// </summary>
    public class ReleaseVehicleCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets license plate.
        /// </summary>
        public string LicensePlate { get; set; }
    }
}
