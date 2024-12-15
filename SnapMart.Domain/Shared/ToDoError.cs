using System.Net.Http.Headers;

namespace SnapMart.Domain.Shared;

public static class ToDoError
{
    public static readonly Error MissingID = new("MISSING_ID", "EmployeeID is missing");
}
