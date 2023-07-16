using MediatR;

namespace APIIntegration.Application.TaskSampleCommands
{
    public class DeleteTaskSampleCommand : IRequest<int>
    {
        public int TaskSampleId { get; set; }
    }
}
