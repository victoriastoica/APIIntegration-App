using MediatR;

namespace APIIntegration.Application.TaskSampleCommands
{
    public class UpdateTaskSampleCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty;
        public bool IsProcessed { get; set; }
        public bool IsDeleted { get; set; }
    }
}
