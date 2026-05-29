namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// ICreateVehicleOutputPort.
    /// </summary>
    public interface ICreateVehicleOutputPort : IOutputPortStandard<CreateVehicleInputOutput>
    {
        /// <summary>
        /// VehicleAlreadyExists. When try to add vehicle with same license plate.
        /// </summary>
        /// <param name="message">message.</param>
        void VehicleAlreadyExists(string message);

        /// <summary>
        /// VehicleTooOld. When try to add vehicle with more than 5 years.
        /// </summary>
        /// <param name="message">message.</param>
        void VehicleTooOld(string message);
    }
}
