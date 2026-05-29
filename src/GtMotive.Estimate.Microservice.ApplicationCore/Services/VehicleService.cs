using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Models.Database;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Services
{
    /// <summary>
    /// VehicleService implementation.
    /// </summary>
    /// <param name="mongoService">Database.</param>
    public class VehicleService(IMongoService mongoService) : IVehicleService
    {
        /// <summary>
        /// Gets get all available vehicles.
        /// </summary>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>List of non reserved vehicles.</returns>
        public async Task<List<VehicleEntity>> GetAllAvailableVehiclesAsync(CancellationToken cancellationToken)
        {
            var collection = await mongoService.GetCollectionAsync<VehicleEntity>(cancellationToken);

            return await collection.Find(x => string.IsNullOrEmpty(x.CustomerPersonIdentificationNumber)).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Adds a vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle to add.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>Added vehicle.</returns>
        public async Task<bool> CreateVehicleAsync(VehicleEntity vehicle, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            if (vehicle.AssemblyDate < DateTime.Now.AddYears(-5))
            {
                throw new DomainException("Assembly date can't be longer than 5 years.");
            }

            var collection = await mongoService.GetCollectionAsync<VehicleEntity>(cancellationToken);

            await collection.InsertOneAsync(vehicle, cancellationToken: cancellationToken);

            return true;
        }

        /// <summary>
        /// Rents a vehicle.
        /// </summary>
        /// <param name="licensePlate">License plate to find.</param>
        /// <param name="customerPin">Customer pin .</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>true if vehicle is rentable.</returns>
        public async Task<bool> RentVehicleAsync(string licensePlate, string customerPin, CancellationToken cancellationToken)
        {
            var collection = await mongoService.GetCollectionAsync<VehicleEntity>(cancellationToken);

            var vehicle = await collection.Find(x => x.LicensePlate == licensePlate).FirstOrDefaultAsync(cancellationToken)
                ?? throw new DomainException($"License Plate:{licensePlate} not found.");

            if (!string.IsNullOrEmpty(vehicle.CustomerPersonIdentificationNumber))
            {
                throw new DomainException($"Vehicle already rented to customer PIN:{vehicle.CustomerPersonIdentificationNumber}.");
            }

            var rentedVehicle = await collection.Find(x => x.CustomerPersonIdentificationNumber == customerPin).FirstOrDefaultAsync(cancellationToken);
            if (rentedVehicle != null)
            {
                throw new DomainException($"Customer already has a vehicle with license Plate:{rentedVehicle.LicensePlate} rented.");
            }

            _ = await collection.FindOneAndUpdateAsync(
                x => x.LicensePlate == vehicle.LicensePlate,
                Builders<VehicleEntity>.Update.Set(x => x.CustomerPersonIdentificationNumber, customerPin),
                cancellationToken: cancellationToken);

            return true;
        }

        /// <summary>
        /// Release a vehicle.
        /// </summary>
        /// <param name="licensePlate">License plate to find.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>true if vehicle is releasable.</returns>
        public async Task<bool> ReleaseVehicleAsync(string licensePlate, CancellationToken cancellationToken)
        {
            var collection = await mongoService.GetCollectionAsync<VehicleEntity>(cancellationToken);

            var vehicle = await collection.Find(x => x.LicensePlate == licensePlate).FirstOrDefaultAsync(cancellationToken)
                ?? throw new DomainException($"License Plate:{licensePlate} not found.");

            if (string.IsNullOrEmpty(vehicle.CustomerPersonIdentificationNumber))
            {
                throw new DomainException("Vehicle not rented.");
            }

            _ = await collection.FindOneAndUpdateAsync(
                x => x.LicensePlate == vehicle.LicensePlate,
                Builders<VehicleEntity>.Update.Set(x => x.CustomerPersonIdentificationNumber, null),
                cancellationToken: cancellationToken);

            return true;
        }
    }
}
