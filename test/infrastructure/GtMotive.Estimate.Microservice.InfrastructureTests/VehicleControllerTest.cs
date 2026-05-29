using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests
{
    public class VehicleControllerTest(GenericInfrastructureTestServerFixture fixture) : IClassFixture<GenericInfrastructureTestServerFixture>
    {
        private readonly HttpClient _client = fixture.Server.CreateClient();

        [Fact]
        public async Task CreateVehicleAsyncTest()
        {
            var response = await _client.GetAsync($"/api/Vehicle/test");

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
