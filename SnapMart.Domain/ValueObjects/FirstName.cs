﻿using SnapMart.Domain.Errors;
using SnapMart.Domain.Primitives;
using SnapMart.Domain.Shared;

namespace SnapMart.Domain.ValueObjects;

public sealed class FirstName : ValueObject
{
    public const int MaxLength = 50;
    private FirstName(string value) => this.Value = value;
    public string Value { get; }
    public static Result<FirstName> Create(string firstName)
    {
        if(string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<FirstName>(DomainErrors.FirstName.Empty);
        }

        if(firstName.Length > MaxLength)
        {
            return Result.Failure<FirstName>(DomainErrors.FirstName.TooLong);
        }

        return new FirstName(firstName);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
