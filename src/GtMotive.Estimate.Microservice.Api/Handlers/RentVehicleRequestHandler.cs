using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Handlers
{
    public class RentVehicleRequestHandler(RentVehiclePresenter presenter, IRentVehicleUseCase useCase) : IRequestHandler<RentVehicleRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(RentVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await useCase.Execute(new RentVehicleInputOutput()
            {
                LicensePlate = request.LicensePlate,
                CustomerPin = request.CustomerPin
            });

            return presenter;
        }
    }
}
