using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Models.Dtos;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Events
{
    /// <summary>
    /// GetAvailableVehicles event.
    /// </summary>
    public class GetAvailableVehiclesQuery : IRequest<List<VehicleDto>>
    {
    }
}
