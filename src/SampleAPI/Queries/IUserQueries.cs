using SampleAPI.Domain;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public interface IUserQueries
    {
        Task<List<BasicUserViewModel>> FindAllAsync();
        Task<BasicUserViewModel> FindByUsernameAsync(string username);
    }
}
