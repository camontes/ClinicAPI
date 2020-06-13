using SampleAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Behaviors
{
    public interface IMedicalAppointmentBehavior
    {
        Task CreateMedicalAppointmentAsync(MedicalAppointment medicalAppointment);
        Task DeleteMedicalAppointmentAsync(MedicalAppointment medicalAppointment);
    }
}
