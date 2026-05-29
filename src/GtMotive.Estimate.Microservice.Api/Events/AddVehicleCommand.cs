using GtMotive.Estimate.Microservice.Domain.Models.Dtos;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Events
{
    /// <summary>
    /// AddVehicle event.
    /// </summary>
    public class AddVehicleCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets vehicle dto data.
        /// </summary>
        public VehicleDto Vehicle { get; set; }
    }
}
