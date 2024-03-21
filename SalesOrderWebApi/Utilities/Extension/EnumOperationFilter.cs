using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Utilities.Extension
{
    public class EnumOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                return;

            foreach (var parameter in operation.Parameters)
            {
                var parameterDescription = context.ApiDescription.ParameterDescriptions.FirstOrDefault(p => p.Name == parameter.Name);
                if (parameterDescription != null)
                {
                    var parameterType = parameterDescription.Type;

                    if (parameterType.IsEnum)
                    {
                        if (parameter.Extensions.TryGetValue("x-ms-enum", out var enumObject) && enumObject is OpenApiObject enumOpenApiObject)
                        {
                            if (enumOpenApiObject.TryGetValue("values", out var valuesAny) && valuesAny is OpenApiArray valuesArray)
                            {
                                var values = valuesArray.Select(v => (v as OpenApiString)?.Value).ToList();
                                parameter.Schema.Enum = (IList<IOpenApiAny>)values;
                            }
                        }
                    }
                }
            }
        }
    }
}
