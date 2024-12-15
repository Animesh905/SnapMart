using MediatR;
using Microsoft.AspNetCore.Mvc;
using SnapMart.Domain.Shared;

namespace SnapMart.WebApi.Abstractions;

public class ApiController : ControllerBase
{
    protected readonly ISender _sender;
    protected ApiController(ISender sender) => _sender = sender;
    protected IActionResult HandleFailure(Result result) =>
    result switch
    {
        { IsSuccess: true } => throw new InvalidOperationException(),
        { IsFailure: true } when result is IValidationResult validationResult =>
            BadRequest(
                CreateProblemDetails(
                    "Validation Error",
                    StatusCodes.Status400BadRequest,
                    IValidationResult.ValidationError,
                    validationResult.Errors.Select(e => new ValidationError
                    {
                        Code = e.Code,
                        Description = e.Description
                    }))),
        _ =>
            BadRequest(
                CreateProblemDetails(
                    "Bad Request",
                    StatusCodes.Status400BadRequest,
                    result.Error))
    };



    private ProblemDetails CreateProblemDetails(
    string title, int status, Error error, IEnumerable<ValidationError> validationErrors = null)
    {
        var problemDetails = new ProblemDetails
        {
            Title = title,
            Status = status,
            Detail = error?.Description
        };

        if (validationErrors != null)
        {
            problemDetails.Extensions["errors"] = validationErrors
                .Select(e => new
                {
                    e.Code,
                    e.Description
                });
        }

        return problemDetails;
    }

}
