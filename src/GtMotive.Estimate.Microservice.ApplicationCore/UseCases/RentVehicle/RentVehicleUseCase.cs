using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.CustomExceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// RentVehicleUseCase.
    /// </summary>
    /// <param name="vehicleRepository">IVehicleRepository.</param>
    /// <param name="outputPort">IRentVehicleOutputPort.</param>
    public class RentVehicleUseCase(IVehicleRepository vehicleRepository, IRentVehicleOutputPort outputPort) : IRentVehicleUseCase
    {
        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">RentVehicleInputOutput.</param>
        /// <returns>task.</returns>
        public async Task Execute(RentVehicleInputOutput input)
        {
            try
            {
                await vehicleRepository.RentVehicleAsync(input?.LicensePlate, input?.CustomerPin);
                outputPort.StandardHandle(input);
            }
            catch (VehicleAlreadyRentedException ex)
            {
                outputPort.VehicleAlreadyRented(ex.Message);
            }
            catch (CustomerAlreadyRentedException ex)
            {
                outputPort.CustomerAlreadyRented(ex.Message);
            }
        }
    }
}
