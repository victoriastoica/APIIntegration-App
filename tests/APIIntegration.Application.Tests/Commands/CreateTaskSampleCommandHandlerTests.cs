using APIIntegration.Application.TaskSampleCommands;
using APIIntegration.Dto;
using APIIntegration.Infrastructure.Repositories;
using APIIntegration.Model.TaskAggregate;
using AutoMapper;
using Moq;
using Xunit;

namespace APIIntegration.Application.Tests.Commands
{
    /// <summary>
    /// unit tests for CreateTaskSampleCommandHandler
    /// </summary>
    public class CreateTaskSampleCommandHandlerTests
    {
        [Fact]
        public async Task HandlerIsProcessedSuccessfully()
        {
            // arrange
            var request = new CreateTaskSampleCommand
            {
                Name = "TaskName",
                Date = DateTime.Now,
                Type = "TaskType"
            };

            TaskSample? taskSampleCreated = null;

            var taskSampleRepositoryMock = new Mock<ITaskSampleRepository>();
            taskSampleRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<TaskSample>()))
                .Callback<object>(y => { taskSampleCreated = y as TaskSample; });

            var mapperMock = new Mock<IMapper>();

            mapperMock.Setup(x => x.Map<TaskSample>(It.IsAny<CreateTaskSampleCommand>()))
                .Returns(new TaskSample("TaskName", DateTime.Now, "TaskType", false, false));

            mapperMock.Setup(x => x.Map<TaskSampleDto>(It.IsAny<TaskSample>()))
                .Returns(new TaskSampleDto { Id = 1 });

            var handler = new CreateTaskSampleCommandHandler(taskSampleRepositoryMock.Object, mapperMock.Object);

            // act
            var response = await handler.Handle(request, new CancellationToken());

            // assert
            Assert.NotNull(response);
            Assert.NotNull(taskSampleCreated);
            Assert.Equal(request.Name, taskSampleCreated?.Name);
            Assert.Equal(request.Type, taskSampleCreated?.Type);
        }

        [Fact]
        public async Task CommandIsProcessedWithError()
        {
            // arrange           
            var request = new CreateTaskSampleCommand
            {
                Name = "TaskName",
                Date = DateTime.Now,
                Type = "TaskType"
            };


            var applicationRepositoryMock = new Mock<ITaskSampleRepository>();
            applicationRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<TaskSample>())).Throws(new Exception());

            var mapperMock = new Mock<IMapper>();

            var handler = new CreateTaskSampleCommandHandler(applicationRepositoryMock.Object, mapperMock.Object);

            // act            
            Func<Task> act = () => handler.Handle(request, new CancellationToken());

            // assert
            await Assert.ThrowsAsync<Exception>(() => act());
        }
    }
}
