using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
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
    public class VehicleController(IAppLogger<VehicleController> logger, IMediator mediator) : ControllerBase
    {
        [HttpGet("get-available-vehicles")]
        [ProducesResponseType<IEnumerable<AvailableVehicleDto>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAvailableVehiclesAsync()
        {
            logger.LogDebug($"{nameof(GetAvailableVehiclesAsync)} requested");

            var presenter = await mediator.Send(new GetAvailableVehiclesRequest());
            return presenter.ActionResult;
        }

        [HttpPost("create")]
        [ProducesResponseType<CreateVehicleInputOutput>(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateVehicleAsync([FromBody][Required] CreateVehicleRequest request)
        {
            logger.LogDebug($"{nameof(CreateVehicleAsync)} requested. {request}", request);

            var presenter = await mediator.Send(request);
            return presenter.ActionResult;
        }

        [HttpPut("rent-vehicle")]
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        public async Task<IActionResult> RentVehicleAsync([FromBody][Required] RentVehicleRequest request)
        {
            logger.LogDebug($"{nameof(RentVehicleAsync)} requested for LP:{request?.LicensePlate} and PIN:{request?.CustomerPin}.");

            var presenter = await mediator.Send(request);
            return presenter.ActionResult;
        }

        [HttpPut("release-vehicle")]
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ReleaseVehicleAsync([FromBody][Required] ReleaseVehicleRequest request)
        {
            logger.LogDebug($"{nameof(ReleaseVehicleAsync)} requested for LP:{request?.LicensePlate}.");

            var presenter = await mediator.Send(request);
            return presenter.ActionResult;
        }

        [HttpGet("test")]
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        public IActionResult Test() => Ok();
    }
}
