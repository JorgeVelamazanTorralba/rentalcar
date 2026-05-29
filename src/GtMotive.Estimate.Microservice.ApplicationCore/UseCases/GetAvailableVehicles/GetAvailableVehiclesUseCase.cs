using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models.Dtos;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAvailableVehicles
{
    /// <summary>
    /// GetAvailableVehiclesUseCase.
    /// </summary>
    /// <param name="vehicleRepository">VehicleRepository.</param>
    /// <param name="port">IGetAvailableVehiclesOutputPort.</param>
    /// <param name="mapper">IMapper.</param>
    public class GetAvailableVehiclesUseCase(IVehicleRepository vehicleRepository, IGetAvailableVehiclesOutputPort port, IMapper mapper) : IGetAvailableVehiclesUseCase
    {
        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">RentalVehicleInputOutput.</param>
        /// <returns>task.</returns>
        public async Task Execute(GetAvailableVehiclesInput input)
        {
            var availableVehicles = await vehicleRepository.GetAvailableVehiclesAsync();

            port.StandardHandle(new GetAvailableVehiclesOutput()
            {
                AvailableVehicles = mapper.Map<List<AvailableVehicleDto>>(availableVehicles)
            });
        }
    }
}
