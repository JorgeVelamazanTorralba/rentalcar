using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Events
{
    /// <summary>
    /// RentVehicle event.
    /// </summary>
    public class RentVehicleCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets license plate.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets customer pin.
        /// </summary>
        public string CustomerPin { get; set; }
    }
}
