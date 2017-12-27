using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CityHospital.Models;
using CityHospital.Dtos;

namespace CityHospital.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Id is the key property for the Movie class, and a key property should not be changed.
            //That’s why we get this exception.To resolve this, you need to tell AutoMapper to ignore
            //Id during mapping of a MovieDto to Movie.            

            CreateMap<Patient, PatientDto>();

            CreateMap<Appointment, AppointmentDto>();

            CreateMap<PatientDto, Patient>()
               .ForMember(m => m.Id, opt => opt.Ignore());

            CreateMap<AppointmentDto, Appointment>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }

    }
}