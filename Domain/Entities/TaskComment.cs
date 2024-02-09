namespace TaskList_BusinessBooster.Domain.Entities
{
    public class TaskComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
    }
}
