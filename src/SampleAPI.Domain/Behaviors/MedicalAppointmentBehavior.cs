using SampleAPI.Domain.Infrastructure;
using SampleAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Behaviors
{
    public class MedicalAppointmentBehavior : IMedicalAppointmentBehavior
    {
        protected readonly IMedicalAppointmentRepository _repository;

        public MedicalAppointmentBehavior(IMedicalAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateMedicalAppointmentAsync(MedicalAppointment medicalAppointment)
        {
            if (medicalAppointment is null) throw new ArgumentNullException(nameof(medicalAppointment));

            await _repository.CreateMedicalAppointmentAsync(medicalAppointment);
        }

        public async Task DeleteMedicalAppointmentAsync(MedicalAppointment medicalAppointment)
        {
            if (medicalAppointment is null) throw new ArgumentNullException(nameof(medicalAppointment));

            await _repository.DeleteMedicalAppointmentAsync(medicalAppointment);
        }
    }
}
