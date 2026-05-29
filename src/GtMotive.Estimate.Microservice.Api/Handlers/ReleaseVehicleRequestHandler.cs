using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReleaseVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Handlers
{
    public class ReleaseVehicleRequestHandler(ReleaseVehiclePresenter presenter, IReleaseVehicleUseCase useCase) : IRequestHandler<ReleaseVehicleRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(ReleaseVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await useCase.Execute(new ReleaseVehicleInputOutput() { LicensePlate = request.LicensePlate });

            return presenter;
        }
    }
}
