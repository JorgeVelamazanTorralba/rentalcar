using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public class RentVehiclePresenter : IWebApiPresenter, IRentVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void VehicleAlreadyRented(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void CustomerAlreadyRented(string message)
        {
            ActionResult = new BadRequestObjectResult(message);
        }

        public void StandardHandle(RentVehicleInputOutput response)
        {
            ActionResult = new OkObjectResult($"Rental success, vehicle with license plate:{response?.LicensePlate} rented to customer: {response?.CustomerPin}.");
        }
    }
}
