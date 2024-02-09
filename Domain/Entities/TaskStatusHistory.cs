using System.ComponentModel.DataAnnotations;

namespace TaskList_BusinessBooster.Domain.Entities
{
    public class TaskStatusHistory
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public string DateChanged { get; set; }
    }
}
