using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public interface IMedicalAppointmentQueries
    {
        Task<List<MedicalAppointmentViewModel>> FindAllAsync();
        Task<MedicalAppointmentViewModel> FindByIdAsync(int id);
        Task<MedicalAppointmentViewModel> FindByCreatedAtUsernameAsync(DateTime createdAt, string username);
        Task<List<MedicalAppointmentViewModel>> FindByUsernameAsync(string username);
    }
}
