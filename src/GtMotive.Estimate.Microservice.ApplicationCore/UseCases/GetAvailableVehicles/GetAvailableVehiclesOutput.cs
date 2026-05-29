using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Models.Dtos;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAvailableVehicles
{
    /// <summary>
    /// GetAvailableVehiclesOutput.
    /// </summary>
    public class GetAvailableVehiclesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets the list of available vehicles.
        /// </summary>
        public List<AvailableVehicleDto> AvailableVehicles { get; set; }
    }
}
