using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.CustomExceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models.Database;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Repositories
{
    /// <summary>
    /// VehicleRepository.
    /// </summary>
    /// <param name="mongoService">mongo utils.</param>
    public class VehicleRepository(IMongoService mongoService) : IVehicleRepository
    {
        /// <summary>
        /// CreateVehicle. Uses FindByFunc internally.
        /// </summary>
        /// <param name="vehicle">entity to add.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>created vehicle.</returns>
        public async Task<VehicleEntity> CreateVehicleAsync(VehicleEntity vehicle, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            var collection = await mongoService.GetCollectionAsync<VehicleEntity>(cancellationToken);

            var existsVehicle = await (await FindByFunc(x => x.LicensePlate == vehicle.LicensePlate, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
            if (existsVehicle != null)
            {
                throw new VehicleAlreadyExistsException($"The license plate: {vehicle.LicensePlate} already exists.");
            }

            if (vehicle.AssemblyDate < DateTime.Now.AddYears(-5))
            {
                throw new VehicleTooOldException("Assembly date can't be longer than 5 years.");
            }

            await collection.InsertOneAsync(vehicle, cancellationToken: cancellationToken);

            return await (await FindByFunc(x => x.LicensePlate == vehicle.LicensePlate, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// RentVehicle. Uses UpdateCustomerPin internally.
        /// </summary>
        /// <param name="licensePlate">license plate to find.</param>
        /// <param name="customerPin">customer pin to rent.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>task.</returns>
        public async Task RentVehicleAsync(string licensePlate, string customerPin, CancellationToken cancellationToken = default)
        {
            var existsVehicle = await (await FindByFunc(x => x.LicensePlate == licensePlate, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
            if (existsVehicle != null && !string.IsNullOrEmpty(existsVehicle.CustomerPersonIdentificationNumber))
            {
                throw new VehicleAlreadyRentedException($"The vehicle with license plate: {licensePlate} is already rented(CIP: {existsVehicle.CustomerPersonIdentificationNumber}).");
            }

            var existsCustomer = await (await FindByFunc(x => !string.IsNullOrEmpty(x.CustomerPersonIdentificationNumber) && x.CustomerPersonIdentificationNumber == customerPin, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
            if (existsCustomer != null)
            {
                throw new CustomerAlreadyRentedException($"The customer with pin: {customerPin} already has a rented vehicle(LP: {existsCustomer.LicensePlate}).");
            }

            await UpdateCustomerPin(licensePlate, customerPin, cancellationToken);
        }

        /// <summary>
        /// ReleaseVehicle. Uses UpdateCustomerPin internally.
        /// </summary>
        /// <param name="licensePlate">license plate to find.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>task.</returns>
        public async Task ReleaseVehicleAsync(string licensePlate, CancellationToken cancellationToken = default)
        {
            var existsVehicle = await (await FindByFunc(x => x.LicensePlate == licensePlate, cancellationToken)).FirstOrDefaultAsync(cancellationToken)
                ?? throw new VehicleNotExistsException($"The license plate: {licensePlate} not exists.");

            if (string.IsNullOrEmpty(existsVehicle.CustomerPersonIdentificationNumber))
            {
                throw new VehicleNotRentedException($"The license plate: {licensePlate} has no customer.");
            }

            await UpdateCustomerPin(licensePlate, null, cancellationToken);
        }

        /// <summary>
        /// GetAvailableVehicles. Uses FindByFunc internally.
        /// </summary>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>list of vehicles or empty.</returns>
        public async Task<List<VehicleEntity>> GetAvailableVehiclesAsync(CancellationToken cancellationToken = default) =>
            await (await FindByFunc(x => string.IsNullOrEmpty(x.CustomerPersonIdentificationNumber), cancellationToken)).ToListAsync(cancellationToken);

        /// <summary>
        /// FindByFunc. Get the IFindFluent result that matches filter.
        /// </summary>
        /// <param name="filter">expression to find for.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>IFindFluent.</returns>
        private async Task<IFindFluent<VehicleEntity, VehicleEntity>> FindByFunc(Expression<Func<VehicleEntity, bool>> filter, CancellationToken cancellationToken = default)
        {
            var collection = await mongoService.GetCollectionAsync<VehicleEntity>(cancellationToken);

            return collection.Find(filter);
        }

        /// <summary>
        /// UpdateCustomerPin.
        /// </summary>
        /// <param name="licensePlate">license plate to find.</param>
        /// <param name="customerPin">customer pin to update.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>true if vehicle's customer pin was updated.</returns>
        private async Task UpdateCustomerPin(string licensePlate, string customerPin, CancellationToken cancellationToken = default)
        {
            var collection = await mongoService.GetCollectionAsync<VehicleEntity>(cancellationToken);

            _ = await collection.FindOneAndUpdateAsync(
                x => x.LicensePlate == licensePlate,
                Builders<VehicleEntity>.Update.Set(x => x.CustomerPersonIdentificationNumber, customerPin),
                cancellationToken: cancellationToken);
        }
    }
}
