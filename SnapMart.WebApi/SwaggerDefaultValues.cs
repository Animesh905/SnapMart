using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SnapMart.WebApi
{
    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // For each parameter, apply default values, if needed
            foreach (var parameter in operation.Parameters)
            {
                parameter.Description ??= "Default description for the parameter";
                parameter.Required |= parameter.Schema.Default == null;
            }
        }
    }
}
