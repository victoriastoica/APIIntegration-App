using APIIntegration.Application.TaskSampleCommands;
using APIIntegration.Dto;
using APIIntegration.Model.TaskAggregate;
using AutoMapper;

namespace APIIntegration.Application.Mappings
{
    public class TaskSampleProfile : Profile
    {
        public TaskSampleProfile()
        {
            CreateMap<TaskSample, TaskSampleDto>();
            CreateMap<CreateTaskSampleCommand, TaskSample>();
            CreateMap<UpdateTaskSampleCommand, TaskSample>();
        }
    }
}
