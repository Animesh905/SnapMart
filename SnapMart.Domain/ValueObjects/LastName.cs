using SnapMart.Domain.Errors;
using SnapMart.Domain.Primitives;
using SnapMart.Domain.Shared;

namespace SnapMart.Domain.ValueObjects
{
    public sealed class LastName : ValueObject
    {
        public const int MaxLength = 50;
        public string Value { get; }
        private LastName(string value) => this.Value = value;

        public static Result<LastName> Create(string LastName)
        {
            if (string.IsNullOrWhiteSpace(LastName))
            {
                return Result.Failure<LastName>(DomainErrors.LastName.Empty);
            }

            if (LastName.Length > MaxLength)
            {
                return Result.Failure<LastName>(DomainErrors.LastName.TooLong);
            }

            return new LastName(LastName);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return this;
        }
    }
}
