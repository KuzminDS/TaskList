namespace TaskList.Core.Models
{
    public class ToDoItem
    {
        public int ToDoItemId { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsFromInbox { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
