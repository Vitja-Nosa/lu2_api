using EverWorld.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("environments")]
public class EnvironmentController : ControllerBase
{
    private readonly UserService _userService;
    private readonly EnvironmentService _environmentService;
    private readonly ObjectService _objectService;

    public EnvironmentController(UserService userService, EnvironmentService environmentService, ObjectService objectService)
    {
        _userService = userService;
        _environmentService = environmentService;
        _objectService = objectService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateEnvironment([FromBody] Environment env)
    {
        User user = await _userService.GetLoggedUserAsync();

        if (user != null) 
        {
            env.UserId = user.Id;

            await _environmentService.CreateEnvironment(env);
            return Ok(new { message = $"Environment created" });
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnvironment(int id)
    {
        User user = await _userService.GetLoggedUserAsync();

        if (user != null)
        {
            await _environmentService.DeleteEnvironment(id);
            return Ok(new { message = "environment is deleted"});
        }
        else
        {
            return NotFound();
        }
    }

    //objects
    [HttpGet("{id}/objects")]
    public async Task<IActionResult> GetObjects(int id)
    {
        IEnumerable<Object2d> objs = await _objectService.GetObjects(id);
        return Ok(objs);
    }

    [HttpPost("{id}/objects")]
    public async Task<IActionResult> CreateObject([FromBody] Object2d obj)
    {
        await _objectService.CreateObject(obj);
        return Ok(obj);
    }

}