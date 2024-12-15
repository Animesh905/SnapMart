using System.Net.Http.Headers;

namespace SnapMart.Domain.Shared;

public static class ToDoError
{
    public static readonly Error MissingID = Error.NotFound("MISSING_ID", "EmployeeID is missing");
}
