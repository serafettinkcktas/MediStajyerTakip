using Microsoft.AspNetCore.Mvc;

namespace Web.Controller;

[ApiController]
[Route("api/[controller]/[action]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Test()
    {
        return Ok("working");
    }
}