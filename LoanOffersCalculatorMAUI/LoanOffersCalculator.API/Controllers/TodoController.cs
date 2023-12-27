using Microsoft.AspNetCore.Mvc;
using LoanOffersCalculator.API.Model;
using LoanOffersCalculator.API.Services;
using System.Security.Policy;

namespace LoanOffersCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {

        private readonly ILogger<TodoController> _logger;
        private readonly ITodoService _appService;
        public TodoController(ILogger<TodoController> logger, ITodoService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        [HttpGet(Name = "GetTodoList")]
        public IEnumerable<ToDoModel> Get()
        {
            _logger.LogInformation("Get Todo list.");
            return _appService.GetToDoList();
        }

        [HttpPost("CreateTodo")]
        public async Task<ActionResult<ToDoModel>> PostTodo(ToDoModel model)
        {
            _logger.LogInformation("Add Todo list.");
            await _appService.AddTodo(model);

            return await Task.FromResult(model);
        }

        [HttpDelete("DeleteTodo/{id}")]
        public async Task<ActionResult<ToDoModel>> DeleteTodo(string id)
        {
            var todo = _appService.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }

            await _appService.DeleteTodo(todo);

            return new ToDoModel()
            {
                Id = todo.Id.ToString(),
                Name = todo.Name,
                Owner = todo.Owner,
                Partition = todo.Partition,
                Completed = todo.Completed
            };
        }
    }
}