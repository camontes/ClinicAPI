using SampleAPI.Commands;
using SampleAPI.Tests.Common;
using SampleAPI.Tests.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleAPI.Tests
{
    public class MedicalAppointmentControllerFunctionalTest : WebTest
    {
        [Fact]
        public async Task GetAllByUsername_UnexistingUser()
        {
            // Execute
            var response = await _client.GetAsync(
                $"{Endpoints.BYUSERNAME}/unknown");
            var content = await response.Content.ReadAsStringAsync();

            // Check
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetById()
        {
            // Execute
            var response = await _client.GetAsync(
                $"{Endpoints.MEDICALAPPOINTMENTS}/-1");
            var content = await response.Content.ReadAsStringAsync();

            // Check
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateMedicalAppointment_InvalidDate()
        {
            // Prepare
            var createMedicalAppointmentCommand = new CreateMedicalAppointmentCommand
            {
                Description = "Sample",
                CreatedAt = DateTime.Now.AddDays(-20),
                Username = "camontes",
                TypeMedicalAppointmentId = 1
            };

            // Execute

            var responseCreate = await _client.PostAsJsonAsync($"{Endpoints.MEDICALAPPOINTMENTS}", createMedicalAppointmentCommand);

            Assert.Equal(HttpStatusCode.BadRequest, responseCreate.StatusCode);

        }

        [Fact]
        public async Task CreateMedicalAppointment_InvalidUsername()
        {
            // Prepare
            var createMedicalAppointmentCommand = new CreateMedicalAppointmentCommand
            {
                Description = "Sample",
                CreatedAt = DateTime.Now.AddDays(15),
                Username = "unknown",
                TypeMedicalAppointmentId = 1
            };

            // Execute

            var responseCreate = await _client.PostAsJsonAsync($"{Endpoints.MEDICALAPPOINTMENTS}", createMedicalAppointmentCommand);

            Assert.Equal(HttpStatusCode.NotFound, responseCreate.StatusCode);

        }


        [Fact]
        public async Task CancelMedicalAppointment()
        {

            // Execute
            var responseDelete = await _client.DeleteAsync($"{Endpoints.MEDICALAPPOINTMENTS}/-300");

            Assert.Equal(HttpStatusCode.NotFound, responseDelete.StatusCode);

        }
    }
}
