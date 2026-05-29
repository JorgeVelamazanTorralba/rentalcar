using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Models.Database;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// IVehicleService.
    /// </summary>
    public interface IVehicleService
    {
        /// <summary>
        /// Gets get all available vehicles.
        /// </summary>
        /// <returns>List of non reserved vehicles.</returns>
        /// <param name="cancellationToken">cancellation token.</param>
        Task<List<VehicleEntity>> GetAllAvailableVehiclesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Adds a vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle to add.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>Added vehicle.</returns>
        Task<bool> CreateVehicleAsync(VehicleEntity vehicle, CancellationToken cancellationToken);

        /// <summary>
        /// Rents a vehicle.
        /// </summary>
        /// <param name="licensePlate">License plate to find.</param>
        /// <param name="customerPin">Customer pin .</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>true if vehicle is rentable.</returns>
        Task<bool> RentVehicleAsync(string licensePlate, string customerPin, CancellationToken cancellationToken);

        /// <summary>
        /// Release a vehicle.
        /// </summary>
        /// <param name="licensePlate">License plate to find.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>true if vehicle is releasable.</returns>
        Task<bool> ReleaseVehicleAsync(string licensePlate, CancellationToken cancellationToken);
    }
}
