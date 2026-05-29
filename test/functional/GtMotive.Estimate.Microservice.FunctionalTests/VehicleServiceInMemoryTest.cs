namespace GtMotive.Estimate.Microservice.FunctionalTests
{
    /// <summary>
    /// Vehicle service in memory database.
    /// </summary>
    internal sealed class VehicleServiceInMemoryTest
    {
        //private readonly MongoDbRunner _runner = MongoDbRunner.Start();
        //private readonly MongoDbSettings _settings = compositionRootTestFixture?.Configuration.GetSection("MongoDb") as MongoDbSettings;

        //[Fact]
        //public async Task InsertarYObtenerFuncionaConMongoDBEnMemoria()
        //{
        //    MongoService mongoService = new MongoService(_settings);

        //    _runner.
        //    //var mongoClient = new MongoClient(_settings.ConnectionString);
        //    //var collection = mongoService. mongoClient.GetDatabase(_settings.MongoDbDatabaseName).GetCollection<VehicleEntity>(_settings.CollectionName);

        //    var service = new VehicleService(mongoClient);

        //    await service.CreateVehicleAsync(new VehicleEntity() { AssemblyDate = DateTime.Now, Description = "description", LicensePlate = "12345-AAA", Model = "Seat" }, CancellationToken.None);

        //    //await collection.InsertOneAsync(new VehicleEntity() { AssemblyDate = DateTime.Now, Description = "description", LicensePlate = "12345-AAA", Model = "Seat" });

        //    var findResult = await collection.Find(x => x.LicensePlate == "12345-AAA").ToListAsync();

        //    findResult.Should().NotBeNull();
        //    findResult.Should().NotBeEmpty();
        //    findResult.Should().HaveCountGreaterThan(0);
        //    findResult[0].LicensePlate.Should().Be("12345-AAA");
        //}
    }
}
