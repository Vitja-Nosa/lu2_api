using Microsoft.AspNetCore.Mvc;

namespace EverWorld.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    [HttpPost]
    public ActionResult Create([FromBody] dynamic data)
    {
        Console.WriteLine($"{data}");
        return Created();
    }
}