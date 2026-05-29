using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Models.Database;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// IVehicleRepository.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// CreateVehicle.
        /// </summary>
        /// <param name="vehicle">entity to add.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>created vehicle.</returns>
        Task<VehicleEntity> CreateVehicleAsync(VehicleEntity vehicle, CancellationToken cancellationToken = default);

        /// <summary>
        /// RentVehicle. Uses UpdateCustomerPin internally.
        /// </summary>
        /// <param name="licensePlate">license plate to find.</param>
        /// <param name="customerPin">customer pin to rent.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>task.</returns>
        Task RentVehicleAsync(string licensePlate, string customerPin, CancellationToken cancellationToken = default);

        /// <summary>
        /// ReleaseVehicle.
        /// </summary>
        /// <param name="licensePlate">license plate to find.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>task.</returns>
        Task ReleaseVehicleAsync(string licensePlate, CancellationToken cancellationToken = default);

        /// <summary>
        /// GetAvailableVehicles.
        /// </summary>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>list of vehicles or empty.</returns>
        Task<List<VehicleEntity>> GetAvailableVehiclesAsync(CancellationToken cancellationToken = default);
    }
}
