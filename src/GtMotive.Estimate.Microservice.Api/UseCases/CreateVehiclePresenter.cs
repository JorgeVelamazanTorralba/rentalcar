using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public class CreateVehiclePresenter : IWebApiPresenter, ICreateVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void VehicleAlreadyExists(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void VehicleTooOld(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void StandardHandle(CreateVehicleInputOutput response)
        {
            ActionResult = new OkObjectResult($"Vehicle with license plate:{response?.LicensePlate} created.");
        }
    }
}
