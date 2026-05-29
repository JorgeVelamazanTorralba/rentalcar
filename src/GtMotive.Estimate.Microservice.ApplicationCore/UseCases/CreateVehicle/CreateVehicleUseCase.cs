using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.CustomExceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models.Database;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// CreateVehicleUseCase.
    /// </summary>
    /// <param name="vehicleRepository">IVehicleRepository.</param>
    /// <param name="outputPort">ICreateVehicleOutputPort.</param>
    /// <param name="mapper">IMapper.</param>
    public class CreateVehicleUseCase(IVehicleRepository vehicleRepository, ICreateVehicleOutputPort outputPort, IMapper mapper) : ICreateVehicleUseCase
    {
        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">CreateVehicleInputOutput.</param>
        /// <returns>task.</returns>
        public async Task Execute(CreateVehicleInputOutput input)
        {
            try
            {
                var vehicle = await vehicleRepository.CreateVehicleAsync(mapper.Map<VehicleEntity>(input));
                outputPort.StandardHandle(mapper.Map<CreateVehicleInputOutput>(vehicle));
            }
            catch (VehicleAlreadyExistsException ex)
            {
                outputPort.VehicleAlreadyExists(ex.Message);
            }
            catch (VehicleTooOldException ex)
            {
                outputPort.VehicleTooOld(ex.Message);
            }
        }
    }
}
