namespace NorskApi.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

public class ErrorsController : ApiController
{
    [HttpGet("/error")]
    [HttpPost("/error")]
    [HttpPut("/error")]
    [HttpDelete("/error")]
    [HttpPatch("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return this.Problem();
    }
}