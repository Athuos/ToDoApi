namespace ToDoAPI.Entities
{
    public class Task
    {
        public int Id { get; set; }

        public string Content { get; set; }
        
        public bool Status { get; set; }

        public DateTime CreatDate { get; set; }

        public DateTime LimDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }

    }
}
