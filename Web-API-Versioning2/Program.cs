
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Web_API_Versioning2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //add Microsoft.AspNetCore.Mvc.Versioning
            builder.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                options.ReportApiVersions = true;

            });

            //add Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
            builder.Services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Inject ConfigureSwaggerOptions
            builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

            var app = builder.Build();

            // Get the service from services collection after the app has built
            var versionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                //register all the API descriptions available in the provider
                app.UseSwaggerUI(options =>
                {
                    foreach (var description in versionDescriptionProvider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant()); //parameters: url and name
                    }
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
