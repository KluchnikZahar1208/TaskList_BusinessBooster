namespace TaskList_BusinessBooster.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public int TaskListId { get; set; }
        public string Status { get; set; }
        public IEnumerable<TaskComment> Comments { get; set; }

        public static readonly List<string> Statuses = new List<string> { "Pending", "In Progress", "Completed" };
    }
}
