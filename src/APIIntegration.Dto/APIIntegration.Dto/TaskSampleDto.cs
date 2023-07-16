using System.ComponentModel.DataAnnotations;

namespace APIIntegration.Dto
{
    public class TaskSampleDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; } = string.Empty;  
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty;
        public bool IsProcessed { get; set; }
        public bool IsDeleted { get; set; }
    }
}
