using APIIntegration.Dto;
using APIIntegration.Infrastructure.Repositories;
using AutoMapper;
using MediatR;

namespace APIIntegration.Application.TaskSampleQueries
{
    public class GetTaskSampleListQueryHandler : IRequestHandler<GetTaskSampleListQuery, List<TaskSampleDto>>
    {
        private readonly ITaskSampleRepository _taskSampleRepository;
        private readonly IMapper _mapper;

        public GetTaskSampleListQueryHandler(ITaskSampleRepository taskSampleRepository, IMapper mapper)
        {
            _taskSampleRepository = taskSampleRepository;
            _mapper = mapper;
        }

        public async Task<List<TaskSampleDto>> Handle(GetTaskSampleListQuery request, CancellationToken cancellationToken)
        {
            var taskSampleList = await _taskSampleRepository.GetAsync();
            var taskSampleListDto = _mapper.Map<List<TaskSampleDto>>(taskSampleList);

            return taskSampleListDto;
        }
    }
}
