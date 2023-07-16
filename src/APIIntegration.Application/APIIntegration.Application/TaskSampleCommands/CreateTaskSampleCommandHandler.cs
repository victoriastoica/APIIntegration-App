using APIIntegration.Infrastructure.Repositories;
using APIIntegration.Model.TaskAggregate;
using AutoMapper;
using MediatR;

namespace APIIntegration.Application.TaskSampleCommands
{
    public class CreateTaskSampleCommandHandler : IRequestHandler<CreateTaskSampleCommand, int>
    {
        private readonly ITaskSampleRepository _taskSampleRepository;
        private readonly IMapper _mapper;

        public CreateTaskSampleCommandHandler(ITaskSampleRepository taskSampleRepository, IMapper mapper)
        {
            _taskSampleRepository = taskSampleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTaskSampleCommand request, CancellationToken cancellationToken)
        {
            var taskSample = _mapper.Map<TaskSample>(request);

            return await _taskSampleRepository.InsertAsync(taskSample);
        }
    }
}
