using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// CreateVehicleInput.
    /// </summary>
    public class CreateVehicleInputOutput : IUseCaseInput, IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets vehicle's license plate.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets vehicle's model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets vehicle's description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets vehicle's assembly date.
        /// </summary>
        public DateTime AssemblyDate { get; set; }
    }
}
