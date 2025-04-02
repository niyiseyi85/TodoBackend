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
    public class AddTodoCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsTodoId()
        {
            // Arrange
            var mockRepository = new Mock<ITodoRepository>();
            var handler = new AddTodoCommandHandler(mockRepository.Object);
            var command = new AddTodoCommand("Test Title", "Test Description");

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            mockRepository.Verify(r => r.AddAsync(It.IsAny<Todo>()), Times.Once);
        }
    }
}
