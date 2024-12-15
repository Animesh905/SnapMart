using SnapMart.Domain.Shared;

namespace SnapMart.Domain.Errors;

public static class DomainErrors
{
    public static class Member
    {
        public static readonly Error EmailAlreadyInUse = new(
            "Member.EmailAlreadyInUse",
            "The specified email is already in use");
    }
    public static class FirstName
    {
        public static readonly Error Empty = new(
            "FirstName.Empty",
            "First name is empty");

        public static readonly Error TooLong = new(
            "LastName.TooLong",
            "FirstName name is too long");
    }
    public static class MiddleName
    {
        public static readonly Error Empty = new(
            "MiddleName.Empty",
            "Middle name is empty");

        public static readonly Error TooLong = new(
            "MiddleName.TooLong",
            "Middle name is too long");
    }
    public static class LastName
    {
        public static readonly Error Empty = new(
            "LastName.Empty",
            "Last name is empty");

        public static readonly Error TooLong = new(
            "LastName.TooLong",
            "Last name is too long");
    }

    public static class Email
    {
        public static readonly Error Empty = new(
            "Email.Empty",
            "Email is empty");

        public static readonly Error InvalidFormat = new(
            "Email.InvalidFormat",
            "Email format is invalid");
    }

    public static class PhoneNo
    {
        public static readonly Error Empty = new(
            "PhoneNo.Empty",
            "Phone Number is empty");

        public static readonly Error TooLong = new(
            "PhoneNo.TooLong",
            "Phone Number is too long");
    }
}
