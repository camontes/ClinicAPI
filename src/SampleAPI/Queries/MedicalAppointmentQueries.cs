using Microsoft.EntityFrameworkCore;
using SampleAPI.Infrastructure;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public class MedicalAppointmentQueries : IMedicalAppointmentQueries
    {
        protected readonly ApplicationDbContext _context;

        public MedicalAppointmentQueries(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<MedicalAppointmentViewModel>> FindAllAsync()
        {
            return await _context.MedicalAppointments.AsNoTracking()
                .Include(t => t.TypeMedicalAppointment)
                .Select(m => new MedicalAppointmentViewModel
                {
                    Id = m.Id,
                    Description = m.Description,
                    CreatedAt = m.CreatedAt,
                    Username = m.Username,
                    TypeMedicalAppointmentId = m.TypeMedicalAppointmentId,
                    TypeMedicalAppointmentName = m.TypeMedicalAppointment.Name
                })
                .ToListAsync();
        }

        public async Task<List<MedicalAppointmentViewModel>> FindByUsernameAsync(string username)
        {
            return await _context.MedicalAppointments.AsNoTracking()
                .Include(t => t.TypeMedicalAppointment)
                .Select(m => new MedicalAppointmentViewModel
                {
                    Id = m.Id,
                    Description = m.Description,
                    CreatedAt = m.CreatedAt,
                    Username = m.Username,
                    TypeMedicalAppointmentId = m.TypeMedicalAppointmentId,
                    TypeMedicalAppointmentName = m.TypeMedicalAppointment.Name
                })
                .Where(m => m.Username == username)
                .ToListAsync();
        }

        public async Task<MedicalAppointmentViewModel> FindByIdAsync(int id)
        {
            return await _context.MedicalAppointments.AsNoTracking()
                .Include(t => t.TypeMedicalAppointment)
                .Select(m => new MedicalAppointmentViewModel
                {
                    Id = m.Id,
                    Description = m.Description,
                    CreatedAt = m.CreatedAt,
                    Username = m.Username,
                    TypeMedicalAppointmentId = m.TypeMedicalAppointmentId,
                    TypeMedicalAppointmentName = m.TypeMedicalAppointment.Name
                })
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<MedicalAppointmentViewModel> FindByCreatedAtUsernameAsync(DateTime createdAt, string username)
        {
            return await _context.MedicalAppointments.AsNoTracking()
                .Include(t => t.TypeMedicalAppointment)
                .Select(m => new MedicalAppointmentViewModel
                {
                    Id = m.Id,
                    Description = m.Description,
                    CreatedAt = m.CreatedAt,
                    Username = m.Username,
                    TypeMedicalAppointmentId = m.TypeMedicalAppointmentId,
                    TypeMedicalAppointmentName = m.TypeMedicalAppointment.Name
                })
                .FirstOrDefaultAsync(m => m.CreatedAt == createdAt  && m.CreatedAt.Value.Year == createdAt.Year && m.CreatedAt.Value.Month == createdAt.Month && m.CreatedAt.Value.Day == createdAt.Day);
        }
    }


}
