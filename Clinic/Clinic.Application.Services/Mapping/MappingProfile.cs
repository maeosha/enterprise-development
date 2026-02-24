using AutoMapper;
using Clinic.Application.DTOs.Patient;
using Clinic.Application.DTOs.Doctor;
using Clinic.Application.DTOs.Specialization;
using Clinic.Application.DTOs.Appointment;
using Clinic.Models.Enums;
using Clinic.Models.Entities;

namespace Clinic.Application.Services.Mapping;

/// <summary>
/// AutoMapper profile for mapping between DTOs and entity models in the Clinic API.
/// Defines the mapping rules for Patient, Doctor, Specialization, and Appointment objects,
/// including custom enum conversions and member mapping settings.
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUpdatePatientDto, Patient>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender)))
            .ForMember(dest => dest.BloodGroup, opt => opt.MapFrom(src => Enum.Parse<BloodGroup>(src.BloodGroup)))
            .ForMember(dest => dest.RhesusFactor, opt => opt.MapFrom(src => Enum.Parse<RhesusFactor>(src.RhesusFactor)));

        CreateMap<Patient, GetPatientDto>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
            .ForMember(dest => dest.BloodGroup, opt => opt.MapFrom(src => src.BloodGroup.ToString()))
            .ForMember(dest => dest.RhesusFactor, opt => opt.MapFrom(src => src.RhesusFactor.ToString()));

        CreateMap<CreateUpdateDoctorDto, Doctor>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender)))
            .ForMember(dest => dest.Specializations, opt => opt.MapFrom(src => src.Specializations));

        CreateMap<Doctor, GetDoctorDto>()
            .ForMember(dest => dest.Specializations, opt => opt.MapFrom(src => src.Specializations.Select(s => s.Name.ToString()).ToList()));

        CreateMap<Specialization, GetSpecializationDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToString()));

        CreateMap<CreateUpdateSpecializationDto, Specialization>();

        CreateMap<Appointment, GetAppointmentDto>();

        CreateMap<CreateUpdateAppointmentDto, Appointment>();
    }
}
