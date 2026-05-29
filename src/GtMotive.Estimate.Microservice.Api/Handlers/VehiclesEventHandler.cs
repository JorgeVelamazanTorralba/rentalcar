using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Events;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models.Database;
using GtMotive.Estimate.Microservice.Domain.Models.Dtos;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Handlers
{
    /// <summary>
    /// VehiclesEventHandler.
    /// </summary>
    /// <param name="vehicleService">vehicle service.</param>
    /// <param name="mapper">mapper.</param>
    public class VehiclesEventHandler(IVehicleService vehicleService, IMapper mapper) :
        IRequestHandler<GetAvailableVehiclesQuery, List<VehicleDto>>,
        IRequestHandler<AddVehicleCommand, bool>,
        IRequestHandler<RentVehicleCommand, bool>,
        IRequestHandler<ReleaseVehicleCommand, bool>
    {
        /// <summary>
        /// Handle event get available vehicles.
        /// </summary>
        /// <param name="request">request.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>list of available vehicles.</returns>
        public async Task<List<VehicleDto>> Handle(GetAvailableVehiclesQuery request, CancellationToken cancellationToken) =>
            mapper.Map<List<VehicleDto>>(await vehicleService.GetAllAvailableVehiclesAsync(cancellationToken));

        /// <summary>
        /// Handle event add vehicle command.
        /// </summary>
        /// <param name="request">request.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>true if the vehicle was added.</returns>
        public async Task<bool> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            ArgumentNullException.ThrowIfNull(request.Vehicle);

            return await vehicleService.CreateVehicleAsync(mapper.Map<VehicleEntity>(request.Vehicle), cancellationToken);
        }

        /// <summary>
        /// Hanldes event rent vehicle.
        /// </summary>
        /// <param name="request">request.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>true if the vehicle was rented.</returns>
        public async Task<bool> Handle(RentVehicleCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            ArgumentException.ThrowIfNullOrEmpty(request.LicensePlate);
            ArgumentException.ThrowIfNullOrEmpty(request.CustomerPin);

            return await vehicleService.RentVehicleAsync(request?.LicensePlate, request?.CustomerPin, cancellationToken);
        }

        /// <summary>
        /// Handle event release vehicle.
        /// </summary>
        /// <param name="request">request.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>true if the vehicle was released.</returns>
        public async Task<bool> Handle(ReleaseVehicleCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            ArgumentException.ThrowIfNullOrEmpty(request.LicensePlate);

            return await vehicleService.ReleaseVehicleAsync(request?.LicensePlate, cancellationToken);
        }
    }
}
