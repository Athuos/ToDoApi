using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Tagname { get; set; }

    }
}
