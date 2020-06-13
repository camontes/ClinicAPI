using AutoMapper;
using SampleAPI.Commands;
using SampleAPI.Domain.Models;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Mappings
{
    public class MedicalAppointmentMappings :Profile
    {
        public MedicalAppointmentMappings()
        {
            CreateMap<CreateMedicalAppointmentCommand, MedicalAppointmentViewModel>();
            CreateMap<MedicalAppointmentViewModel, MedicalAppointment>();
        }
    }
}
