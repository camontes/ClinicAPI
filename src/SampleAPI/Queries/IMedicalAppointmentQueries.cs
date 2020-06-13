using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    interface IMedicalAppointmentQueries
    {
        Task<List<MedicalAppointmentViewModel>> FindAllAsync();
        Task<MedicalAppointmentViewModel> FindByIdAsync(int id);
        Task<MedicalAppointmentViewModel> FindByCretedAtAsync(DateTime createdAt);
        Task<List<MedicalAppointmentViewModel>> FindByUsernameAllAsync(string username);
    }
}
