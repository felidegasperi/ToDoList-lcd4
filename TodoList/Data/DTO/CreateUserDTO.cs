using System.ComponentModel.DataAnnotations;

namespace TodoList.Data.DTO
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage ="Este campo es necesario")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public string Address { get; set; }
    }
}
