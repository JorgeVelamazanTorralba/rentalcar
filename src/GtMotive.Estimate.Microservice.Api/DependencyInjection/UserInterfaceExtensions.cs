using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAvailableVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReleaseVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddSingleton<CreateVehiclePresenter>();
            services.AddScoped<ICreateVehicleOutputPort>(x => x.GetRequiredService<CreateVehiclePresenter>());

            services.AddSingleton<GetAvailableVehiclesPresenter>();
            services.AddScoped<IGetAvailableVehiclesOutputPort>(x => x.GetRequiredService<GetAvailableVehiclesPresenter>());

            services.AddSingleton<ReleaseVehiclePresenter>();
            services.AddScoped<IReleaseVehicleOutputPort>(x => x.GetRequiredService<ReleaseVehiclePresenter>());

            services.AddSingleton<RentVehiclePresenter>();
            services.AddScoped<IRentVehicleOutputPort>(x => x.GetRequiredService<RentVehiclePresenter>());

            return services;
        }
    }
}
