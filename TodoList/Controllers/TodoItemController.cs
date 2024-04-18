using Microsoft.AspNetCore.Mvc;
using TodoList.Data.DTO;
using TodoList.Services.Interfaces;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemController(ITodoItemService todoItemService) 
        {
            _todoItemService = todoItemService;
        }

        [HttpGet("{todoItemId}")]
        public IActionResult GetTodoItemById(int todoItemId) 
        { 
            try
            {
                var todoItem = _todoItemService.GetTodoItemById(todoItemId);
                return Ok(todoItem);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetTodosByIdUser/{userId}")]
        public IActionResult GetTodoItemsByIdUser(int userId)
        {
            try
            {
                var todoItems = _todoItemService.GetTodoItemsByIdUser(userId);
                if (todoItems == null || todoItems.Count == 0)
                    return NotFound();

                return Ok(todoItems);
            }
            catch
            { 
                return BadRequest(); 
            }
        }

        [HttpPost]
        public IActionResult CreateTodoItem(CreateTodoItemDTO createTodoItemDTO)
        {
            try
            {
                var newTodo = _todoItemService.CreateTodoItem(createTodoItemDTO);
                return CreatedAtAction(nameof(GetTodoItemById), new { todoItemId = newTodo.Id_todo_item }, newTodo);

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
