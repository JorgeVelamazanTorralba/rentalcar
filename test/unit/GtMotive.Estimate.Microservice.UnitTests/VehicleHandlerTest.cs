using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Events;
using GtMotive.Estimate.Microservice.Api.Handlers;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models.Database;
using GtMotive.Estimate.Microservice.Domain.Models.Dtos;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests
{
    /// <summary>
    /// VehicleHandlerTest.
    /// </summary>
    public class VehicleHandlerTest
    {
        private readonly AddVehicleCommand _request;
        private readonly Mock<IVehicleService> _mockedVehicleService;
        private readonly Mock<IMapper> _mockedAutoMapper;

        private readonly VehiclesEventHandler _sut;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleHandlerTest"/> class.
        /// </summary>
        public VehicleHandlerTest()
        {
            _request = new AddVehicleCommand()
            {
                Vehicle = new VehicleDto() { AssemblyDate = "2025/12/12", Description = "description", LicensePlate = "12345-AAA", Model = "Seat" }
            };

            _mockedVehicleService = new Mock<IVehicleService>();
            _mockedVehicleService
                .Setup(x => x.CreateVehicleAsync(It.IsAny<VehicleEntity>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            _mockedAutoMapper = new Mock<IMapper>();
            _mockedAutoMapper
                .Setup(x => x.Map<VehicleEntity>(It.IsAny<VehicleDto>())).Returns(new VehicleEntity());

            _sut = new VehiclesEventHandler(_mockedVehicleService.Object, _mockedAutoMapper.Object);
        }

        /// <summary>
        /// AddVehicleReturs true.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task AddVehicleReturnsTrue()
        {
            var result = await _sut.Handle(_request, CancellationToken.None);

            Assert.True(result);

            _mockedAutoMapper.Verify(x => x.Map<VehicleEntity>(It.IsAny<VehicleDto>()), Times.Once);
            _mockedVehicleService.Verify(x => x.CreateVehicleAsync(It.IsAny<VehicleEntity>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
