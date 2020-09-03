using AutoMapper;
using ClinicManagement.Core.DTOs;
using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagement.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Patient, PatientDto>();
            Mapper.CreateMap<City, CityDto>();
            Mapper.CreateMap<Doctor, DoctorDto>();
            Mapper.CreateMap<Specialization, SpecializationDto>();
            //Mapper.CreateMap<DoctorFormViewModel, Doctor>();
        }
    }
}