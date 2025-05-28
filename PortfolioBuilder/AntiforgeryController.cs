using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AntiforgeryController : ControllerBase
{
    [HttpGet("token")]
    public IActionResult GetAntiforgeryToken([FromServices] IAntiforgery antiforgery)
    {
        var tokens = antiforgery.GetAndStoreTokens(HttpContext);
        return new JsonResult(new { token = tokens.RequestToken });
    }
}
