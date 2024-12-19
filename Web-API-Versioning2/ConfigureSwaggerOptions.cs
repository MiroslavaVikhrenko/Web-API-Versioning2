using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Web_API_Versioning2
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        //Inject the provider
        private readonly IApiVersionDescriptionProvider apiVersionDescriptionProvider;
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            this.apiVersionDescriptionProvider = apiVersionDescriptionProvider;
        }
        public void Configure(string? name, SwaggerGenOptions options)
        {
            throw new NotImplementedException();
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var option in options)
            {

            }
        }
    }
}
