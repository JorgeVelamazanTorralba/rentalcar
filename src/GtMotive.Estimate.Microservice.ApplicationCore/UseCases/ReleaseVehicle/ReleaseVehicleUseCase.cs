using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.CustomExceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReleaseVehicle
{
    /// <summary>
    /// ReleaseVehicleUseCase.
    /// </summary>
    /// <param name="vehicleRepository">IVehicleRepository.</param>
    /// <param name="outputPort">IReleaseVehicleOutputPort.</param>
    public class ReleaseVehicleUseCase(IVehicleRepository vehicleRepository, IReleaseVehicleOutputPort outputPort) : IReleaseVehicleUseCase
    {
        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">ReleaseVehicleInputOutput.</param>
        /// <returns>task.</returns>
        public async Task Execute(ReleaseVehicleInputOutput input)
        {
            try
            {
                await vehicleRepository.ReleaseVehicleAsync(input?.LicensePlate);
                outputPort.StandardHandle(input);
            }
            catch (VehicleNotExistsException ex)
            {
                outputPort.VehicleNotExists(ex.Message);
            }
            catch (VehicleNotRentedException ex)
            {
                outputPort.VehicleNotRented(ex.Message);
            }
        }
    }
}
