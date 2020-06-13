using Microsoft.EntityFrameworkCore;
using SampleAPI.Domain;
using SampleAPI.Infrastructure;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public class UserQueries : IUserQueries
    {
        protected readonly ApplicationDbContext _context;

        public UserQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BasicUserViewModel>> FindAllAsync()
        {
            return await _context.Users.AsNoTracking()
                .Include(u => u.Rol)
                .Select(u => new BasicUserViewModel
                {
                    Username = u.Username,
                    Name = u.Name,
                    Email = u.Email,
                    RolName = u.Rol.Name,
                    Password = u.Password,
                    RolId = u.RolId
                })
                .ToListAsync();
        }

        public async Task<BasicUserViewModel> FindByUsernameAsync(string username)
        {
            return await _context.Users.AsNoTracking()
                .Include(u => u.Rol)
                .Select(u => new BasicUserViewModel
                {
                    Username = u.Username,
                    Name = u.Name,
                    Email = u.Email,
                    RolName = u.Rol.Name,
                    Password = u.Password,
                    RolId = u.RolId
                })
                .FirstOrDefaultAsync(user => user.Username == username);
        }

    }
}
