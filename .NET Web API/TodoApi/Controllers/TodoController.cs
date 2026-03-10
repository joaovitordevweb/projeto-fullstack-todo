using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    // Simulação de banco de dados na memória
    private static List<TodoItem> _items = new List<TodoItem>
    {
        new TodoItem { Id = 1, Name = "Aprender .NET Framework", IsComplete = false },
        new TodoItem { Id = 2, Name = "Dominar o Vue.js", IsComplete = false }
    };

    // GET: api/todo
    [HttpGet]
    public ActionResult<List<TodoItem>> GetAll()
    {
        return Ok(_items);
    }

    // POST: api/todo
    [HttpPost]
    public IActionResult Create(TodoItem item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
        return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
    }
}