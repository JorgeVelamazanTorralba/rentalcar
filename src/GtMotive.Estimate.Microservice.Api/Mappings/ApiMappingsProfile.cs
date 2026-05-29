using System;
using System.Globalization;
using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.Models.Database;
using GtMotive.Estimate.Microservice.Domain.Models.Dtos;

namespace GtMotive.Estimate.Microservice.Api.Mappings
{
    /// <summary>
    /// ApiMappingProfile.
    /// </summary>
    public class ApiMappingsProfile : Profile
    {
        private readonly string[] _formats = ["yyyy/MM/dd", "yyyy-MM-dd"];

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiMappingsProfile"/> class.
        /// </summary>
        public ApiMappingsProfile()
        {
            CreateMap<VehicleEntity, VehicleDto>()
                .ForMember(x => x.AssemblyDate, opt => opt.MapFrom(src => src.AssemblyDate.ToShortDateString()))
            .ReverseMap()
                .ForMember(x => x.AssemblyDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.AssemblyDate, _formats, CultureInfo.InvariantCulture, DateTimeStyles.None)));
        }
    }
}
