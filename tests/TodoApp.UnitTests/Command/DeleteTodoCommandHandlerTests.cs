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
    public class DeleteTodoCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_DeletesTodo()
        {
            // Arrange
            var mockRepository = new Mock<ITodoRepository>();
            var todo = new Todo { Id = Guid.NewGuid() };

            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(todo);
            var handler = new DeleteTodoCommandHandler(mockRepository.Object);
            var command = new DeleteTodoCommand(todo.Id);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            mockRepository.Verify(r => r.DeleteAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}
