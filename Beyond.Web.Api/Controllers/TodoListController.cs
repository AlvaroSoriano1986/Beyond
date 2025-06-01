using Beyond.Application.Contracts;
using Beyond.Classes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Beyond.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListApplication _todoListApplication;

        public TodoListController(ITodoListApplication todoListApplication)
        {
            _todoListApplication = todoListApplication;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var todoList = _todoListApplication.GetTodoList();

            if (todoList == null)
            {
                return NotFound();
            }

            return Ok(todoList);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] TodoItem todoItem)
        {
            try
            {
                _todoListApplication.AddItem(todoItem.Title, todoItem.Description, todoItem.Category);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem([FromBody] TodoItem todoItem)
        {
            try
            {
                _todoListApplication.UpdateItem(todoItem.Id, todoItem.Description);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                _todoListApplication.RemoveItemById(id);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        [Route("{id}/progression")]
        public async Task<IActionResult> RegisterProgression(int id, [FromBody] decimal percentage)
        {
            try
            {
                _todoListApplication.RegisterProgression(id, DateTime.Now, percentage);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
