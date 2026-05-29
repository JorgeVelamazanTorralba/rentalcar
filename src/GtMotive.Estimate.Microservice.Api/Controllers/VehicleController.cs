using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Events;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class VehicleController(IAppLogger<VehicleController> logger, IMediator mediatr) : ControllerBase
    {
        [HttpGet("get-available-vehicles")]
        [ProducesResponseType<IEnumerable<VehicleDto>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAvailableVehiclesAsync()
        {
            logger.LogInformation($"{nameof(GetAvailableVehiclesAsync)} requested");

            return Ok(await mediatr.Send(new GetAvailableVehiclesQuery()));
        }

        [HttpPost("create")]
        [ProducesResponseType<VehicleDto>(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleDto>> CreateVehicleAsync([FromBody] VehicleDto vehicle)
        {
            logger.LogInformation($"{nameof(CreateVehicleAsync)} requested.");

            var result = await mediatr.Send(new AddVehicleCommand() { Vehicle = vehicle });

            return result
                ? Ok(vehicle)
                : BadRequest("Unable to add vehicle");
        }

        [HttpPut("rent-vehicle")]
        [ProducesResponseType<VehicleDto>(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleDto>> RentVehicleAsync([FromBody] RentPurposeDto rentPurpose)
        {
            logger.LogInformation($"{nameof(RentVehicleAsync)} requested for LP:{rentPurpose?.LicensePlate} and PIN:{rentPurpose?.CustomerPin}.");

            var result = await mediatr.Send(new RentVehicleCommand() { LicensePlate = rentPurpose.LicensePlate, CustomerPin = rentPurpose.CustomerPin });

            return result
                ? Ok($"Vehicle with LP: {rentPurpose.LicensePlate} rented to customer PIN: {rentPurpose?.CustomerPin}.")
                : BadRequest($"Unable to rent vehicle with LP: {rentPurpose.LicensePlate} to customer PIN: {rentPurpose?.CustomerPin}.");
        }

        [HttpPut("release-vehicle/{licensePlate}")]
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        public async Task<ActionResult> ReleaseVehicleAsync([FromRoute] string licensePlate)
        {
            logger.LogInformation($"{nameof(ReleaseVehicleAsync)} requested for LP:{licensePlate}.");

            var result = await mediatr.Send(new ReleaseVehicleCommand() { LicensePlate = licensePlate });

            return result
                ? Ok($"Vehicle with LP: {licensePlate} released.")
                : BadRequest($"Unable to release wehicle with LP: {licensePlate}.");
        }

        [HttpGet("test")]
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        public IActionResult Test() => Ok();
    }
}
