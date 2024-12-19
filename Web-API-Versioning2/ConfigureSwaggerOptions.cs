using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Web_API_Versioning2
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        
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
