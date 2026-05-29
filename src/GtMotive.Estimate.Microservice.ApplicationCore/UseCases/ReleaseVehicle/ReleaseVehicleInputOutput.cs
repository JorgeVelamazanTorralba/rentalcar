namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReleaseVehicle
{
    /// <summary>
    /// RentalVehicleInput.
    /// </summary>
    public class ReleaseVehicleInputOutput : IUseCaseInput, IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets vehicle's license plate.
        /// </summary>
        public string LicensePlate { get; set; }
    }
}
