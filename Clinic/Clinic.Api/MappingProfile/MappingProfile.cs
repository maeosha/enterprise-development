using AutoMapper;
using Clinic.Api.DTOs.PatientDto;
using Clinic.Api.DTOs.DoctorDto;
using Clinic.Api.DTOs.SpecializationDto;
using Clinic.Api.DTOs.Appointment;
using Clinic.Models.Enums;
using Clinic.Models.Entities;

namespace Clinic.Api.MappingProfile;

/// <summary>
/// AutoMapper profile for mapping between DTOs and entity models in the Clinic API.
/// Defines the mapping rules for Patient, Doctor, Specialization, and Appointment objects,
/// including custom enum conversions and member mapping settings.
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreatePatientDto, Patient>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender)))
            .ForMember(dest => dest.BloodGroup, opt => opt.MapFrom(src => Enum.Parse<BloodGroup>(src.BloodGroup)))
            .ForMember(dest => dest.RhesusFactor, opt => opt.MapFrom(src => Enum.Parse<RhesusFactor>(src.RhesusFactor)));

        CreateMap<Patient, GetPatientDto>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
            .ForMember(dest => dest.BloodGroup, opt => opt.MapFrom(src => src.BloodGroup.ToString()))
            .ForMember(dest => dest.RhesusFactor, opt => opt.MapFrom(src => src.RhesusFactor.ToString()));

        CreateMap<UpdatePatientDto, Patient>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<CreateDoctorDto, Doctor>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender)))
            .ForMember(dest => dest.Specializations, opt => opt.MapFrom(src => src.Specializations));

        CreateMap<Doctor, GetDoctorDto>()
            .ForMember(dest => dest.Specializations, opt => opt.MapFrom(src => src.Specializations.Select(s => s.Name.ToString()).ToList()));

        CreateMap<UpdateDoctorDto, Doctor>()
            .ForMember(d => d.Specializations, opt => opt.Ignore())
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Specialization, GetSpecializationDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToString()));

        CreateMap<CreateSpecializationDto, Specialization>();

        CreateMap<Appointment, GetAppointmentDto>();

        CreateMap<CreateAppointmentDto, Appointment>();

        CreateMap<UpdateAppointmentDto, Appointment>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
