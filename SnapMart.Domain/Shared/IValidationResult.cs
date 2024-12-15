using System.Net.NetworkInformation;

namespace SnapMart.Domain.Shared;

public interface IValidationResult
{
    public static Error ValidationError = new(
        "ValidationError",
        "A validation problem occured."
        );

    Error[] Errors { get; } 
}
