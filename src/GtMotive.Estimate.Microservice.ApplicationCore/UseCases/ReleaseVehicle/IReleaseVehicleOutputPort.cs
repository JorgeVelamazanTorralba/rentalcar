namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReleaseVehicle
{
    /// <summary>
    /// IReleaseVehicleOutputPort.
    /// </summary>
    public interface IReleaseVehicleOutputPort : IOutputPortStandard<ReleaseVehicleInputOutput>
    {
        /// <summary>
        /// VehicleAlreadyExists. When none vehicle has found by license plate.
        /// </summary>
        /// <param name="message">message.</param>
        void VehicleNotExists(string message);

        /// <summary>
        /// VehicleTooOld. When vehicle is not rented.
        /// </summary>
        /// <param name="message">message.</param>
        void VehicleNotRented(string message);
    }
}
