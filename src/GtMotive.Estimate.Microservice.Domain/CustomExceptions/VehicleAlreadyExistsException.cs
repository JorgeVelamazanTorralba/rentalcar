using System;
using System.Diagnostics.CodeAnalysis;

namespace GtMotive.Estimate.Microservice.Domain.CustomExceptions
{
    /// <summary>
    /// LicensePlateNotExistsException.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class VehicleAlreadyExistsException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyExistsException"/> class.
        /// </summary>
        public VehicleAlreadyExistsException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public VehicleAlreadyExistsException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public VehicleAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
