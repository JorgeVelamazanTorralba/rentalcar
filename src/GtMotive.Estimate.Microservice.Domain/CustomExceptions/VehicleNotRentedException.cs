using System;
using System.Diagnostics.CodeAnalysis;

namespace GtMotive.Estimate.Microservice.Domain.CustomExceptions
{
    /// <summary>
    /// CustomerPinNotExistsException.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class VehicleNotRentedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleNotRentedException"/> class.
        /// </summary>
        public VehicleNotRentedException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleNotRentedException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public VehicleNotRentedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleNotRentedException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public VehicleNotRentedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
