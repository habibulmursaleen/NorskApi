namespace NorskApi.Api.Controllers;

using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NorskApi.Api.Common.Http;

[ApiController]

public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count == 0)
        {
            return Problem();
        }

        if (errors.TrueForAll(error => error.Type == ErrorType.Validation))
        {
            return ValidationProblems(errors);
        }

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        return this.Problems(errors[0]);
    }

    private IActionResult Problems(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: error.Description);
    }

    private IActionResult ValidationProblems(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();
        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(error.Code, error.Description);
        }
        return ValidationProblem(modelStateDictionary);
    }
}