using SnapMart.Domain.Errors;
using SnapMart.Domain.Primitives;
using SnapMart.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapMart.Domain.ValueObjects
{
    public sealed class MiddleName : ValueObject
    {
        public const int MaxLength = 50;
        public string Value { get; }
        private MiddleName(string value) => this.Value = value;

        public static Result<MiddleName> Create(string middlename)
        {
            if (string.IsNullOrWhiteSpace(middlename))
            {
                return Result.Failure<MiddleName>(DomainErrors.MiddleName.Empty);
            }

            if (middlename.Length > MaxLength)
            {
                return Result.Failure<MiddleName>(DomainErrors.MiddleName.TooLong);
            }

            return new MiddleName(middlename);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return this;
        }
    }
}
