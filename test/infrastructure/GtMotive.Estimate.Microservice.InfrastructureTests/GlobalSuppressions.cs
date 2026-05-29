// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "For avoid xUnit1027.", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure.TestServerCollectionFixture")]
[assembly: SuppressMessage("Usage", "xUnit1000:Test classes must be public", Justification = "<pendiente>", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.InfrastructureTests.VehicleControllerTest")]
[assembly: SuppressMessage("Maintainability", "CA1515:Considere la posibilidad de hacer que los tipos públicos sean internos", Justification = "<pendiente>", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure.GenericInfrastructureTestServerFixture")]
[assembly: SuppressMessage("Usage", "CA2234:Pasar objetos URI de sistema en lugar de cadenas", Justification = "<pendiente>", Scope = "member", Target = "~M:GtMotive.Estimate.Microservice.InfrastructureTests.VehicleControllerTest.CreateVehicleAsyncTest~System.Threading.Tasks.Task")]
