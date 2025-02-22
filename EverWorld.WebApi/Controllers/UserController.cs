using Microsoft.AspNetCore.Mvc;

namespace EverWorld.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    [HttpPost(Name = "CreateUser")]
    public ActionResult Create([FromBody] dynamic data)
    {
        Console.WriteLine($"{data}");
        return Created();
    }
}