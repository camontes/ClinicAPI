using AutoMapper;
using Newtonsoft.Json;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.Migrations.Data;
using SampleAPI.Tests.Common;
using SampleAPI.Tests.Util;
using SampleAPI.ViewModels;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SampleAPI.Tests
{
    public class UsersControllerFunctionalTest : WebTest
    {

        [Fact]
        public async Task GetByUsername_UnexistingUser_ReturnsError()
        {
            // Execute
            var response = await _client.GetAsync(
                $"{Endpoints.USERS}/unknown");
            var content = await response.Content.ReadAsStringAsync();

            // Check
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }


        [Fact]
        public async Task Update_username_Error()
        {
            // Prepare
            var updateUserCommand = new UpdateUserCommand
            {
                Email = "hola@hotmail.com",
                Name = "juan",
                RolId =1
            };

            // Execute
            var responseUpdate = await _client.PutAsJsonAsync($"{Endpoints.USERS}/unknown", updateUserCommand);

            Assert.Equal(HttpStatusCode.NotFound, responseUpdate.StatusCode);

        }

        [Fact]
        public async Task delete_username_Error()
        {

            // Execute
            var responseDelete = await _client.DeleteAsync($"{Endpoints.USERS}/unknown");

            Assert.Equal(HttpStatusCode.NotFound, responseDelete.StatusCode);

        }

        [Fact]
        public async Task ValidateCredentialsUser()
        {
            // Prepare
            var loginCommand = new LoginCommand
            {
                Password = "password123"
            };

            // Execute
            var responseUpdate = await _client.PostAsJsonAsync($"{Endpoints.VALIDATE}/unknown", loginCommand);

            Assert.Equal(HttpStatusCode.NotFound, responseUpdate.StatusCode);

        }
    }
}
