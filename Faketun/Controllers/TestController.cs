using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Faketun.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
// [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class TestController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] {"value1", "value2"};
    }

    [HttpGet("{id}", Name = "Get")]
    public string Get(int id)
    {
        return "value";
    }
}