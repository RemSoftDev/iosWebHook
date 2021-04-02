using iosWebHook.models;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;
using System.Text.Json;

namespace iosWebHook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : Controller
    {
        TodoContext todoContext;
        public MessagesController(TodoContext todoContext)
        {
            this.todoContext = todoContext;
        }
        [HttpGet("/[controller]/{dateFrom}")]
        public IActionResult get(DateTime dateFrom)
        {
            var res = todoContext.messages.Where(z =>z.created > dateFrom).ToList();
            return Ok(res);
        }

        [HttpPost]
        public IActionResult post([FromBody]dynamic val)
        {
            var str = JsonSerializer.Serialize(val);
            todoContext.messages.Add(new messages() { message = str, created = DateTime.UtcNow });
            todoContext.SaveChanges();

            return Ok();
        }
    }
}
