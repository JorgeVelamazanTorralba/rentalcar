using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAvailableVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Handlers
{
    public class GetAvailableVehiclesRequestHandler(GetAvailableVehiclesPresenter presenter, IGetAvailableVehiclesUseCase useCase) : IRequestHandler<GetAvailableVehiclesRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(GetAvailableVehiclesRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await useCase.Execute(new GetAvailableVehiclesInput());

            return presenter;
        }
    }
}
