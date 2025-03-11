using EverWorld.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

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
        User user = await _userService.GetLoggedUserAsync("CfDJ8MgujF22qHRKhw9wVpd2jvoLjZ9r_WEOebDid8q3tUhN0m8HtAOchgLGywM8ovztRKeAnv9gLNBdgWWuxkk1Xv9kXt5a4cw5krqRENjHJvIWWgQYO3DfIKqHTCisQjXt5_DMJihd9dmeFGrQIIHPiEU9I9aEl4mLPWt0IsxklZiOXQMUeEZdDqPsZm3s-aTRxrBNvclDtObIT9P7L10wyX2t-_BjQNBYElR985RSBg5yruBWK1nNKXMLRUvtdPbclrVSPzTaK3q9GVfkSdslzsYaitA61hxgKY9wb5coUt16iL53QQ_UAXp9IGMghxanYu8e2_cLnTxhjmH5Iz3lR1syY7TbHFiJRiznJoG-e-oHqRHlL5sGpIrgSX9cAr5G8ioGfUQt29aCmPK6bzwM9ZDQULoWRx8SsM1nEn7Yp9M8etykz-fZdmj8CAifCO4cPqBvjZ-Yc2ImAh5YiLGhTBdqR1PXReU0Uws78P0ov3phJL0K4dVAjxootJdM_VzddKMSxJGbl8u-ngAhIAnocjp0fkG8eQm_hptjAbgdXbDOidVEqRokw199OxLTqufaRm1CrhP7j6_T4CfdjE8K4nL7ZKqlFDSWmX4RprmufxH5z90AaGz6tgde2Zt7DgHdKxCc1vjmHTZg2eInYf6lAr3_cdGAEOQ_wdUUYmNdZDssVKDfI0CmkfONHJWV9WV4-K6aows1yUjJoy3ks08-vYg");

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
        User user = await _userService.GetLoggedUserAsync("CfDJ8MgujF22qHRKhw9wVpd2jvoLjZ9r_WEOebDid8q3tUhN0m8HtAOchgLGywM8ovztRKeAnv9gLNBdgWWuxkk1Xv9kXt5a4cw5krqRENjHJvIWWgQYO3DfIKqHTCisQjXt5_DMJihd9dmeFGrQIIHPiEU9I9aEl4mLPWt0IsxklZiOXQMUeEZdDqPsZm3s-aTRxrBNvclDtObIT9P7L10wyX2t-_BjQNBYElR985RSBg5yruBWK1nNKXMLRUvtdPbclrVSPzTaK3q9GVfkSdslzsYaitA61hxgKY9wb5coUt16iL53QQ_UAXp9IGMghxanYu8e2_cLnTxhjmH5Iz3lR1syY7TbHFiJRiznJoG-e-oHqRHlL5sGpIrgSX9cAr5G8ioGfUQt29aCmPK6bzwM9ZDQULoWRx8SsM1nEn7Yp9M8etykz-fZdmj8CAifCO4cPqBvjZ-Yc2ImAh5YiLGhTBdqR1PXReU0Uws78P0ov3phJL0K4dVAjxootJdM_VzddKMSxJGbl8u-ngAhIAnocjp0fkG8eQm_hptjAbgdXbDOidVEqRokw199OxLTqufaRm1CrhP7j6_T4CfdjE8K4nL7ZKqlFDSWmX4RprmufxH5z90AaGz6tgde2Zt7DgHdKxCc1vjmHTZg2eInYf6lAr3_cdGAEOQ_wdUUYmNdZDssVKDfI0CmkfONHJWV9WV4-K6aows1yUjJoy3ks08-vYg");

        if (user != null)
        {
            IEnumerable<Environment> ?environments = await _environmentService.GetUserEnvironments(user.Id);
            return Ok(new { message = "Environments retrieved successfully", environments });
        }
        else
        {
            return NotFound();
        }

    }
}