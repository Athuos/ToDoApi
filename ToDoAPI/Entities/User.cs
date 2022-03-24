namespace ToDoAPI.Entities
{
    public class User
    {

        public int Id { get; set; }

        public string name { get; set; }

        public List<Task> Tasks { get; set; }

    }
}
