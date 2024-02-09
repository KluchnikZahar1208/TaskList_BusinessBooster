namespace TaskList_BusinessBooster.Domain.Entities
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
