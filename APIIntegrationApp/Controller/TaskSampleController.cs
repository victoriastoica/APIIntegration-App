using APIIntegration.Application.TaskRequests;
using APIIntegration.Application.TaskSampleCommands;
using APIIntegration.Application.TaskSampleQueries;
using APIIntegration.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace APIIntegrationApp.Controller
{
    public class TaskSampleController : BaseController
    {
        private readonly ISender _sender;

        public TaskSampleController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TaskSampleDto>> Get(int id)
        {
            var request = new GetTaskSampleQuery { Id = id };
            return await _sender.Send(request);
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskSampleDto>>> GetAll()
        {
            var request = new GetTaskSampleListQuery();
            return await _sender.Send(request);
        }
        
        [HttpPost]
        public async Task<ActionResult> Create(CreateTaskSampleCommand newTaskSample)
        {
            var response = await _sender.Send(newTaskSample);
            return response > 0 ? Ok() : StatusCode(500);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateTaskSampleCommand editedTaskSample)
        {
            var response = await _sender.Send(editedTaskSample);
            return response > 0 ? Ok() : StatusCode(500);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int taskSampleId)
        {
            var response = await _sender.Send(new DeleteTaskSampleCommand { TaskSampleId = taskSampleId });
            return response > 0 ? Ok() : StatusCode(500);
        }
    }
}
