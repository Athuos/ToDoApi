using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Entities
{
    public class Task
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Content { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public bool Status { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [DataType(DataType.Date)]
        public DateTime CreatDate { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [DataType(DataType.Date)]
        public DateTime LimDate { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int UserId { get; set; }

        public User User { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int TagId { get; set; }

        public Tag Tag { get; set; }

    }
}
