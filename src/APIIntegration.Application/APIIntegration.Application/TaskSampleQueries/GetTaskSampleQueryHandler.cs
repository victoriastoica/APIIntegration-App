using APIIntegration.Dto;
using APIIntegration.Infrastructure.Repositories;
using AutoMapper;
using MediatR;

namespace APIIntegration.Application.TaskRequests
{
    public class GetTaskSampleQueryHandler : IRequestHandler<GetTaskSampleQuery, TaskSampleDto>
    {
        private readonly ITaskSampleRepository _taskSampleRepository;
        private readonly IMapper _mapper;

        public GetTaskSampleQueryHandler(ITaskSampleRepository taskSampleRepository, IMapper mapper)
        {
            _taskSampleRepository = taskSampleRepository;
            _mapper = mapper;
        }

        public async Task<TaskSampleDto> Handle(GetTaskSampleQuery request, CancellationToken cancellationToken)
        {
            var taskSample = await _taskSampleRepository.GetByIdAsync(request.Id);

            var taskSampleDto = _mapper.Map<TaskSampleDto>(taskSample);

            return taskSampleDto;
        }
    }
}
