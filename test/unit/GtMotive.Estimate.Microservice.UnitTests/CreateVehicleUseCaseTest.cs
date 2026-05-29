using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models.Database;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests
{
    /// <summary>
    /// CreateVehicleRequestHandler.
    /// </summary>
    public class CreateVehicleUseCaseTest
    {
        private readonly CreateVehicleInputOutput _input;
        private readonly VehicleEntity _result;
        private readonly Mock<IVehicleRepository> _vehicleRepositoryMock;
        private readonly Mock<ICreateVehicleOutputPort> _outputPortMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CreateVehicleUseCase _sut;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleUseCaseTest"/> class.
        /// </summary>
        public CreateVehicleUseCaseTest()
        {
            _input = new CreateVehicleInputOutput() { AssemblyDate = DateTime.Now, Description = "description", LicensePlate = "12345-AAA", Model = "Seat" };
            _result = new VehicleEntity { AssemblyDate = DateTime.Now, Description = "description", LicensePlate = "12345-AAA", Model = "Seat" };

            _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            _vehicleRepositoryMock.Setup(x => x.CreateVehicleAsync(It.IsAny<VehicleEntity>(), It.IsAny<CancellationToken>())).ReturnsAsync(_result);

            _outputPortMock = new Mock<ICreateVehicleOutputPort>();
            _outputPortMock.Setup(x => x.StandardHandle(It.IsAny<CreateVehicleInputOutput>()));

            _mapperMock = new Mock<IMapper>();
            _mapperMock.Setup(x => x.Map<VehicleEntity>(It.IsAny<CreateVehicleInputOutput>())).Returns(_result);
            _mapperMock.Setup(x => x.Map<CreateVehicleInputOutput>(It.IsAny<VehicleEntity>())).Returns(_input);

            _sut = new CreateVehicleUseCase(_vehicleRepositoryMock.Object, _outputPortMock.Object, _mapperMock.Object);
        }

        /// <summary>
        /// AddVehicleTest.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task AddVehicleTest()
        {
            await _sut.Execute(_input);

            _mapperMock.Verify(x => x.Map<VehicleEntity>(It.IsAny<CreateVehicleInputOutput>()), Times.Once);
            _mapperMock.Verify(x => x.Map<CreateVehicleInputOutput>(It.IsAny<VehicleEntity>()), Times.Once);

            _vehicleRepositoryMock.Verify(x => x.CreateVehicleAsync(It.IsAny<VehicleEntity>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
