using APIIntegration.Model.Common;

namespace APIIntegration.Model.TaskAggregate
{
    public class TaskSample : AggregateRoot
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }

        public TaskSample(string name, DateTime date, string type, bool isProcessed, bool isDeleted)
        {
            Name = name;
            Date = date;
            Type = type;
            IsProcessed = isProcessed;
            IsDeleted = isDeleted;
        }

        public TaskSample(int id, string name, DateTime date, string type, bool isProcessed, bool isDeleted): this(name, date, type, isProcessed, isDeleted)
        {
            Id = id;
        }
    }
}
