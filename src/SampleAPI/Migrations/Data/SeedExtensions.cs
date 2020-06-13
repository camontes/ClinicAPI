using Microsoft.EntityFrameworkCore;
using SampleAPI.Domain;
using SampleAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPI.Migrations.Data
{
    public static class SeedExtensions
    {
        public static readonly User[] UsersSeed = new User[] {
            new User
            {
                Username = "Administrator",
                Email = "Administrator@email.com",
                Password ="Admin123",
                Name = "Mr. Administrator",
                RolId = 1
            }
        };

        public static readonly Rol[] RolesSeed = new Rol[] {
            new Rol
            {
                Id = 1,
                Name = "Admin"
            },
            new Rol
            {
                Id = 2,
                Name = "User"
            }
        };

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               UsersSeed
            );
            modelBuilder.Entity<Rol>().HasData(
              RolesSeed
           );
        }
    }
}
