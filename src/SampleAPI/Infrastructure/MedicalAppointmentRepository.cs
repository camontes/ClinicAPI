using SampleAPI.Domain.Infrastructure;
using SampleAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Infrastructure
{
    public class MedicalAppointmentRepository : IMedicalAppointmentRepository
    {
        protected readonly ApplicationDbContext _context;

        public MedicalAppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateMedicalAppointmentAsync(MedicalAppointment medicalAppointment)
        {
            _context.MedicalAppointments.Add(medicalAppointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMedicalAppointmentAsync(MedicalAppointment medicalAppointment)
        {
            _context.MedicalAppointments.Remove(medicalAppointment);
            await _context.SaveChangesAsync();
        }
    }
}
