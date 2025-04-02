using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using TodoApp.Infrastructure.Data;
using System.Net.Http.Json;


namespace TodoApp.IntegrationTests.Controller
{
    public class TodosControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public TodosControllerTests(WebApplicationFactory<Program> factory)
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
        public async Task GetTodos_ReturnsOk()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/todos");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task AddTodo_ReturnsOk()
        {
            // Arrange
            var client = _factory.CreateClient();
            var todo = new { Title = "Test Todo", Description = "Test Description" };

            // Act
            var response = await client.PostAsJsonAsync("/api/todos", todo);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UpdateTodo_ReturnsNoContent()
        {
            // Arrange
            var client = _factory.CreateClient();
            var todo = new { Title = "Test Todo", Description = "Test Description" };
            var addResponse = await client.PostAsJsonAsync("/api/todos", todo);
            var todoId = await addResponse.Content.ReadFromJsonAsync<Guid>();

            var updatedTodo = new { Title = "Updated Todo", Description = "Updated Description" };

            // Act
            var updateResponse = await client.PutAsJsonAsync($"/api/todos/{todoId}", updatedTodo);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, updateResponse.StatusCode);
        }

        [Fact]
        public async Task DeleteTodo_ReturnsNoContent()
        {
            // Arrange
            var client = _factory.CreateClient();
            var todo = new { Title = "Test Todo", Description = "Test Description" };
            var addResponse = await client.PostAsJsonAsync("/api/todos", todo);
            var todoId = await addResponse.Content.ReadFromJsonAsync<Guid>();

            // Act
            var deleteResponse = await client.DeleteAsync($"/api/todos/{todoId}");

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        }
    }
}
