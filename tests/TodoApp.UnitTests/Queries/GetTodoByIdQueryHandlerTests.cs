using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Todos.Queries;
using TodoApp.Core.Domain;
using TodoApp.Core.Interface;

namespace TodoApp.UnitTests.Queries
{
    public class GetTodoByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ValidQuery_ReturnsTodo()
        {
            // Arrange
            var mockRepository = new Mock<ITodoRepository>();
            var todo = new Todo { Id = Guid.NewGuid(), Title = "Test Title", Description = "Test Description" };

            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(todo);
            var handler = new GetTodoByIdQueryHandler(mockRepository.Object);
            var query = new GetTodoByIdQuery(todo.Id);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(todo.Id, result.Id);
            Assert.Equal(todo.Title, result.Title);
            Assert.Equal(todo.Description, result.Description);
        }
    }
}
