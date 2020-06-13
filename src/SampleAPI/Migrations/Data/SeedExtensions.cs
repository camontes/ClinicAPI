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

        public static readonly TypeMedicalAppointment[] TypeMedicalAppointmentsSeed = new TypeMedicalAppointment[] {
            new TypeMedicalAppointment
            {
                Id = 1,
                Name = "Medicina General"
            },
             new TypeMedicalAppointment
            {
                Id = 2,
                Name = "Odontología"
            },
              new TypeMedicalAppointment
            {
                Id = 3,
                Name = "Pediatría"
            },
               new TypeMedicalAppointment
            {
                Id = 4,
                Name = "Neurología"
            },
        };

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               UsersSeed
            );
            modelBuilder.Entity<Rol>().HasData(
              RolesSeed
           );
            modelBuilder.Entity<TypeMedicalAppointment>().HasData(
             TypeMedicalAppointmentsSeed
          );
        }
    }
}
