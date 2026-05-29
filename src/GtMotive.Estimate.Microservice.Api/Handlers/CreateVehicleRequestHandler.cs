using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Handlers
{
    public class CreateVehicleRequestHandler(CreateVehiclePresenter presenter, ICreateVehicleUseCase useCase) : IRequestHandler<CreateVehicleRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await useCase.Execute(new CreateVehicleInputOutput()
            {
                AssemblyDate = request.AssemblyDate,
                Description = request.Description,
                LicensePlate = request.LicensePlate,
                Model = request.Model,
            });

            return presenter;
        }
    }
}
