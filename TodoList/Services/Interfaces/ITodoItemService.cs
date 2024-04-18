using TodoList.Data.DTO;

namespace TodoList.Services.Interfaces
{
    public interface ITodoItemService
    {
        //metodos que se tienen q implementar y lo que recibe
        TodoItemDTO GetTodoItemById(int todoItemId);
        List<TodoItemDTO> GetTodoItemsByIdUser(int userId);
        TodoItemDTO CreateTodoItem(CreateTodoItemDTO createTodoItemDTO);
    }
}
