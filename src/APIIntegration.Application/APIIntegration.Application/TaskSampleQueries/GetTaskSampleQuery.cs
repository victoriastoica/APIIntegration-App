using APIIntegration.Dto;
using MediatR;

namespace APIIntegration.Application.TaskRequests
{
    //query to filter the tasks
    public class GetTaskSampleQuery : IRequest<TaskSampleDto>
    {

        /// <summary>
        /// gets or sets the task id.
        /// </summary>
        public int Id { get; set; }
    }
}
