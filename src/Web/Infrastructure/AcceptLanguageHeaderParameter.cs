using NSwag;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace Mac.CarHub.Web.Infrastructure;

public class AcceptLanguageHeaderParameter : IOperationProcessor
{
    public bool Process(OperationProcessorContext context)
    {
        var existingParameter = context.OperationDescription.Operation.Parameters
            .FirstOrDefault(p => p.Name.Equals("Accept-Language", StringComparison.OrdinalIgnoreCase));

        if (existingParameter is null)
        {
            var parameter = new OpenApiParameter
            {
                Name = "Accept-Language",
                Kind = OpenApiParameterKind.Header,
                Description = "Language preference for the response.",
                IsRequired = false,
                // IsNullableRaw = true,
                // Default = "ar-EG",
                Schema = new NJsonSchema.JsonSchema()
                {
                    Type = NJsonSchema.JsonObjectType.String,
                    Item = new NJsonSchema.JsonSchema() { Type = NJsonSchema.JsonObjectType.String },
                },
            };

            parameter.Schema.Enumeration.Add("ar-EG");
            parameter.Schema.Enumeration.Add("en-US");
            context.OperationDescription.Operation.Parameters.Add(parameter);
        }

        return true;
    }
}
