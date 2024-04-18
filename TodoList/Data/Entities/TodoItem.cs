using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Data.Entities
{
    public class TodoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_todo_item { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //creamos la clave foranea
        [ForeignKey("Id_user")]
        public int Id_user { get; set; }

        // Navegación al usuario propietario
        public User User { get; set; }
    }
}
