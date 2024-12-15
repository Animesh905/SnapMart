using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using SnapMart.Application.Members.Commands;
using SnapMart.Domain.Shared;
using SnapMart.WebApi.Abstractions;
using SnapMart.WebApi.Extensions;
using SnapMart.WebApi.SmartWeb.Member.Contracts;

namespace SnapMart.WebApi.SmartWeb.Member.Controllers;

[ApiVersion(1, Deprecated = true)]
[ApiVersion(2)]
[Route("api/v{version:apiVersion}/[controller]")]
public class MemberController : ApiController
{
    public MemberController(ISender sender) 
        : base(sender)
    {

    }

    [HttpPost("RegisterMember")]
    [MapToApiVersion(1)]
    [EnableRateLimiting("TokenBucketPolicy")]
    public async Task<IResult> RegisterMember(
        [FromBody] RegisterMemberRequest request,
        CancellationToken cancellationToken)
    {
        
        var command = new CreateMemberCommand(
            request.FirstName, 
            request.LastName, 
            request.MobileNumber, 
            request.Email, 
            request.Password);

        Result<Guid> result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        
    }
}
