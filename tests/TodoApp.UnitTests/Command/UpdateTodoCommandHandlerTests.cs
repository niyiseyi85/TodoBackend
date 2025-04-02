using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Todos.Command;
using TodoApp.Core.Domain;
using TodoApp.Core.Interface;

namespace TodoApp.UnitTests.Command
{
    public class UpdateTodoCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_UpdatesTodo()
        {
            // Arrange
            var mockRepository = new Mock<ITodoRepository>();
            var todo = new Todo { Id = Guid.NewGuid(), Title = "Old Title", Description = "Old Description" };

            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(todo);
            var handler = new UpdateTodoCommandHandler(mockRepository.Object);
            var command = new UpdateTodoCommand(todo.Id, "New Title", "New Description");

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("New Title", todo.Title);
            Assert.Equal("New Description", todo.Description);
            mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Todo>()), Times.Once);
        }
    }
}
