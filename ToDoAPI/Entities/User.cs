using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Entities
{
    public class User
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string name { get; set; }

        public List<Task> Tasks { get; set; }

    }
}
