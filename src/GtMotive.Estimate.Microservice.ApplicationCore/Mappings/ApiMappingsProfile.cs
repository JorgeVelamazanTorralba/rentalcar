using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Domain.Models.Database;
using GtMotive.Estimate.Microservice.Domain.Models.Dtos;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Mappings
{
    /// <summary>
    /// ApiMappingProfile.
    /// </summary>
    public class ApiMappingsProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiMappingsProfile"/> class.
        /// </summary>
        public ApiMappingsProfile()
        {
            CreateMap<VehicleEntity, CreateVehicleInputOutput>()
                .ReverseMap();

            CreateMap<VehicleEntity, AvailableVehicleDto>();
        }
    }
}
