using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using System.Net;
using VesselManagementSystemAPI.Models;
using VesselManagementSystemAPI;
using VesselManagementSystemAPI.DTOs;

namespace VesselManagementSystemAPI.Tests
{
    public class IntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public IntegrationTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_All_Ships_Returns_OK1()
        {
            var response = await _client.GetAsync("/api/Ship");

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error Response: " + content);
            }

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Get_All_Ships_Returns_OK()
        {
            var response = await _client.GetAsync("/api/Ship");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_Ships_With_Details_Returns_OK()
        {
            var response = await _client.GetAsync("/api/Ship/GetWithDetails");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_Ship_Creates_And_Returns_Created()
        {
            var newShip = new
            {
                ShipName = "Test Ship",
                ImoNumber = 9212231,
                ShipType = "Cruise",
                ShipTonnage = 220021,
                OwnerIDs = new[] { 1, 2 }
            };

            var response = await _client.PostAsJsonAsync("/api/Ship", newShip);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Put_Ship_Updates_And_Returns_NoContent()
        {
            // First, create a ship
            var ship = new
            {
                ShipName = "Test Ship",
                ImoNumber = 9212231,
                ShipType = "Cruise",
                ShipTonnage = 220021,
                OwnerIDs = new[] { 1, 2 }
            };

            var createResponse = await _client.PostAsJsonAsync("/api/Ship", ship);
            var createdShip = await createResponse.Content.ReadFromJsonAsync<ShipDtoWithDetails>();

            createdShip.Id = 1;

            Assert.NotNull(createdShip);
            Assert.True(createdShip.Id > 0, "Created ship should have a valid ID");
            
            // Modify it
            var updatedShip = new
            {
                ShipName = "Test Ship updated",
                ImoNumber = 9999999,
                ShipType = "Cruise2",
                ShipTonnage = 222222,
                OwnerIDs = new[] { 1, 2 }
            };

            var updateResponse = await _client.PutAsJsonAsync($"/api/Ship/{createdShip.Id}", updatedShip);

            Assert.Equal(HttpStatusCode.NoContent, updateResponse.StatusCode);
        }

        [Fact]
        public async Task Delete_Ship_Returns_NoContent()
        {
            // First, create a ship
            var ship = new
            {
                ShipName = "Test Ship",
                ImoNumber = 9212231,
                ShipType = "Cruise",
                ShipTonnage = 220021,
                OwnerIDs = new[] { 1, 2 }
            };

            var createResponse = await _client.PostAsJsonAsync("/api/Ship", ship);
            var createdShip = await createResponse.Content.ReadFromJsonAsync<Ship>();
            createdShip.Id = 1;
            Assert.NotNull(createdShip);

            // Delete it
            var deleteResponse = await _client.DeleteAsync($"/api/Ship/{createdShip.Id}");

            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        }
    }
}