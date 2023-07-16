using APIIntegration.Dto;
using MediatR;

namespace APIIntegration.Application.TaskSampleQueries
{
    public class GetTaskSampleListQuery : IRequest<List<TaskSampleDto>>
    {
    }
}
