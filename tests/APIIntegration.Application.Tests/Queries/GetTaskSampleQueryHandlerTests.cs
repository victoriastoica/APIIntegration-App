using APIIntegration.Application.TaskRequests;
using APIIntegration.Dto;
using APIIntegration.Infrastructure.Repositories;
using APIIntegration.Model.TaskAggregate;
using AutoMapper;
using Moq;
using Xunit;

namespace APIIntegration.Application.Tests.Queries
{
    /// <summary>
    /// unit tests for GetTaskSampleQueryHandler
    /// </summary>
    public class GetTaskSampleQueryHandlerTests
    {
        [Fact]
        public async Task HandlerIsProcessedSuccessfullyForRequestId()
        {
            //arrange
            var query = new GetTaskSampleQuery{Id = 1};

            var taskSampleRepositoryMock = new Mock<ITaskSampleRepository>();
            taskSampleRepositoryMock
                .Setup(x => x.GetByIdAsync(query.Id))
                .ReturnsAsync(() => new TaskSample("Task1", DateTime.Now, "Type1", false, false));

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<TaskSampleDto>(It.IsAny<TaskSample>()))
                     .Returns(new TaskSampleDto { Id = 1 });

            var queryHandler = new GetTaskSampleQueryHandler(taskSampleRepositoryMock.Object, mapperMock.Object);

            // act
            var response = await queryHandler.Handle(query, new CancellationToken());

            // assert
            Assert.NotNull(response);
            Assert.Equal(query.Id, response.Id);
        }
    }
}
