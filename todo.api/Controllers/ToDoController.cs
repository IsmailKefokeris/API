using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo.api.Interfaces;
using todo.api.Models;

namespace todo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        //private readonly DataContext _context;

        //public ToDoController(DataContext context)
        //{
        //    _context = context;
        //}

        private readonly IToDoItemRepository _toDoItemRepository;

        public ToDoController(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        public DataContext DataContext { get; }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItem>>> Get() 
        {
            var item = await _toDoItemRepository.GetAll();
            if (item == null)
            {
                return BadRequest("Item not found");
            }

            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> Get(int id)
        {
            var item = await _toDoItemRepository.GetItemById(id);
            if (item == null)
            {
                return BadRequest("Item not found");
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<ToDoItem>>> AddItem(ToDoItem item)
        {
            ToDoItem i = new ToDoItem
            {
                Id = item.Id,
                Task = item.Task,
                Description = item.Description,
                IsCompleted = item.IsCompleted
            };

            return Ok(await _toDoItemRepository.AddItem(i));
        }

        [HttpPut]
        public async Task<ActionResult<List<ToDoItem>>> UpdateItem(ToDoItem item)
        {
            var req = await _toDoItemRepository.UpdateItem(item);
            if (req == null)
            {
                return BadRequest("Error Updating Item");
            }

            return Ok(req);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ToDoItem>>> UpdateIsComplete(int id)
        {
            var req = await _toDoItemRepository.UpdateIsCompleted(id);
            if (req == null)
            {
                return BadRequest("Item not found");
            }

            return Ok(req);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ToDoItem>>> Delete(int id)
        {

            var req = await _toDoItemRepository.DeleteItem(id);
            if (req == null)
            {
                return BadRequest("Item not found");
            }

            return Ok(req);

        }
    }
}
