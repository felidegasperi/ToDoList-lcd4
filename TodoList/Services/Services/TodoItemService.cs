using TodoList.Data.Context;
using TodoList.Data.DTO;
using TodoList.Data.Entities;
using TodoList.Services.Interfaces;

namespace TodoList.Services.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ToDoListContext _context;

        public TodoItemService(ToDoListContext context)
        {
            _context = context; //inyeccion de dep
        }

        //completar
        public TodoItemDTO GetTodoItemById(int todoItemId)
        {
            try
            {
                var todoItem = _context.TodoItems.SingleOrDefault(t => t.Id_todo_item == todoItemId);
                if (todoItem == null)
                {
                    throw new Exception($"No se encontro el ToDoItem con el id {todoItemId}");
                }

                //mapea el TodoItem a un TodoItemDTO
                var todoItemDTO = new TodoItemDTO()
                {
                    Id_todo_item = todoItem.Id_todo_item,
                    Title = todoItem.Title,
                    Description = todoItem.Description,
                    UserId = todoItem.Id_user
                };

                return todoItemDTO;
            }
            catch (Exception)
            {
                throw new Exception($"Error al tratar de recuperar el TodoItem");
            }
        }

        public List<TodoItemDTO> GetTodoItemsByIdUser(int userId)
        {
            try
            {
                var todoItems = _context.TodoItems
                    .Where(item => item.Id_user == userId)
                    .Select(item => new TodoItemDTO()
                    {
                        Id_todo_item = item.Id_todo_item,
                        Title = item.Title,
                        Description = item.Description,
                        UserId = item.Id_user
                    })
                    .ToList();

                return todoItems;
            }
            catch (Exception ) 
            {
                throw new Exception($"Error al obtener los TodoItems del usuario con el id {userId}");
            }
        }

        public TodoItemDTO CreateTodoItem(CreateTodoItemDTO createTodoItemDTO)
        {
            try
            {
                var newTodo = new TodoItem
                {
                    Title = createTodoItemDTO.Title,
                    Description = createTodoItemDTO.Description,
                    Id_user = createTodoItemDTO.UserId
                };

                _context.TodoItems.Add(newTodo);
                _context.SaveChanges();

                return new TodoItemDTO
                {
                    Id_todo_item = newTodo.Id_todo_item,
                    Title = newTodo.Title,
                    Description = newTodo.Description,
                    UserId = newTodo.Id_user
                };
            }
            catch (Exception )
            {
                throw new Exception($"Error al crear el TodoItem");
            }
        }
    }
}
