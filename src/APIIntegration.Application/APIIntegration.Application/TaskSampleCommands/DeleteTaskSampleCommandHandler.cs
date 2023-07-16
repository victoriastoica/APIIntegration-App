using APIIntegration.Infrastructure.Repositories;
using MediatR;

namespace APIIntegration.Application.TaskSampleCommands
{
    public class DeleteTaskSampleCommandHandler : IRequestHandler<DeleteTaskSampleCommand, int>
    {
        private readonly ITaskSampleRepository _taskSampleRepository;

        public DeleteTaskSampleCommandHandler(ITaskSampleRepository subcriptionRepository)
        {
            _taskSampleRepository = subcriptionRepository;
        }

        public async Task<int> Handle(DeleteTaskSampleCommand request, CancellationToken cancellationToken)
        {
            var response = await _taskSampleRepository.SoftDeleteAsync(request.TaskSampleId);

            return response;
        }
    }
}
