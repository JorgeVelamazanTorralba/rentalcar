namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// IRentVehicleOutputPort.
    /// </summary>
    public interface IRentVehicleOutputPort : IOutputPortStandard<RentVehicleInputOutput>
    {
        /// <summary>
        /// VehicleAlreadyExists. When vehicle already has been rented.
        /// </summary>
        /// <param name="message">message.</param>
        void VehicleAlreadyRented(string message);

        /// <summary>
        /// VehicleTooOld. When customer has already a vehicle rented.
        /// </summary>
        /// <param name="message">message.</param>
        void CustomerAlreadyRented(string message);
    }
}
