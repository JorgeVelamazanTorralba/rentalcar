namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// RentVehicleInputOutput.
    /// </summary>
    public class RentVehicleInputOutput : IUseCaseInput, IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets vehicle's license plate.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets customer's pin.
        /// </summary>
        public string CustomerPin { get; set; }
    }
}
