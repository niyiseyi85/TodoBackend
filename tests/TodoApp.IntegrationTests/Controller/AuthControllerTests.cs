using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using TodoApp.Infrastructure.Data;
using System.Net.Http.Json;

namespace TodoApp.IntegrationTests.Controller
{
    public class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public AuthControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Replace the database with an in-memory database for testing
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<TodoDbContext>));

                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    services.AddDbContext<TodoDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("TestDatabase");
                    });
                });
            });
        }

        [Fact]
        public async Task RegisterUser_ReturnsOk()
        {
            // Arrange
            var client = _factory.CreateClient();
            var user = new { Email = "test@example.com", Password = "Password123!" };

            // Act
            var response = await client.PostAsJsonAsync("/api/auth/register", user);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task LoginUser_ReturnsToken()
        {
            // Arrange
            var client = _factory.CreateClient();
            var user = new { Email = "test@example.com", Password = "Password123!" };

            // Register the user first
            await client.PostAsJsonAsync("/api/auth/register", user);

            // Act
            var response = await client.PostAsJsonAsync("/api/auth/login", user);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var token = await response.Content.ReadAsStringAsync();
            Assert.NotNull(token);
        }

        [Fact]
        public async Task ForgotPassword_ReturnsToken()
        {
            // Arrange
            var client = _factory.CreateClient();
            var user = new { Email = "test@example.com", Password = "Password123!" };

            // Register the user first
            await client.PostAsJsonAsync("/api/auth/register", user);

            // Act
            var response = await client.PostAsJsonAsync("/api/auth/forgot-password", new { Email = user.Email });

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var token = await response.Content.ReadAsStringAsync();
            Assert.NotNull(token);
        }

        [Fact]
        public async Task ResetPassword_ReturnsOk()
        {
            // Arrange
            var client = _factory.CreateClient();
            var user = new { Email = "test@example.com", Password = "Password123!" };

            // Register the user first
            await client.PostAsJsonAsync("/api/auth/register", user);

            // Get a password reset token
            var forgotPasswordResponse = await client.PostAsJsonAsync("/api/auth/forgot-password", new { Email = user.Email });
            var token = await forgotPasswordResponse.Content.ReadAsStringAsync();

            // Act
            var resetPasswordResponse = await client.PostAsJsonAsync("/api/auth/reset-password", new
            {
                Email = user.Email,
                Token = token,
                NewPassword = "NewPassword123!"
            });

            // Assert
            Assert.Equal(HttpStatusCode.OK, resetPasswordResponse.StatusCode);
        }
    }
}
