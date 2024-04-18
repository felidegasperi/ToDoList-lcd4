namespace TodoList.Data.DTO
{
    public class TodoItemDTO
    {
        public int Id_todo_item { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; } //clave foranea de Id_user
    }
}
