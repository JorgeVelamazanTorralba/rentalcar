using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAvailableVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public class GetAvailableVehiclesPresenter : IWebApiPresenter, IGetAvailableVehiclesOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(GetAvailableVehiclesOutput response)
        {
            ActionResult = new OkObjectResult(response?.AvailableVehicles);
        }
    }
}
