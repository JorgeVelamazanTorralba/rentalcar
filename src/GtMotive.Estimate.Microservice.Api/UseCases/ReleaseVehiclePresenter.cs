using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReleaseVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public class ReleaseVehiclePresenter : IWebApiPresenter, IReleaseVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void VehicleNotExists(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void VehicleNotRented(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void StandardHandle(ReleaseVehicleInputOutput response)
        {
            ActionResult = new OkObjectResult($"Release success, vehicle with license plate:{response?.LicensePlate} released.");
        }
    }
}
