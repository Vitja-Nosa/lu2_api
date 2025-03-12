using EverWorld.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("environments")]
public class EnvironmentController : ControllerBase
{
    private readonly UserService _userService;
    private readonly EnvironmentService _environmentService;

    public EnvironmentController(UserService userService, EnvironmentService environmentService)
    {
        _userService = userService;
        _environmentService = environmentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateEnvironment([FromBody] Environment env)
    {
        User user = await _userService.GetLoggedUserAsync();


        if (user != null) 
        {
            env.UserId = user.Id;

            await _environmentService.CreateEnvironment(env);
            return Ok(new { message = $"Environment set to " });
        } else
        {
            return NotFound();
        }

    }

    [HttpGet("")]
    public async Task<IActionResult> GetUserEnvironments()
    {
        User user = await _userService.GetLoggedUserAsync();

        if (user != null)
        {
            IEnumerable<Environment> ?environments = await _environmentService.GetUserEnvironments(user.Id);
            return Ok(environments);
        }
        else
        {
            return NotFound();
        }

    }
}