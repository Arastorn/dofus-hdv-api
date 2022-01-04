using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using NodaTime;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Dofus.Tools.Api.Modules
{
    public static class OpenApiExtensions
    {
        public static void AddOpenApi(this IServiceCollection services)
        {
            var versions = new Dictionary<string, OpenApiInfo>
            {
                { "v1", new OpenApiInfo { Title = "Dofus Tools API", Version = "1" } }
            };

            SwaggerGenOptions MapOption(SwaggerGenOptions options)
            {
                options.MapType<Instant>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString(Instant.FromDateTimeUtc(DateTime.UtcNow).ToString()),
                    Format = "date-time"
                });
                options.MapType<Instant?>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString(Instant.FromDateTimeUtc(DateTime.UtcNow).ToString()),
                    Format = "date-time"
                });

                return options;
            }

            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName);
                options.CustomOperationIds(apiDesc => apiDesc.TryGetMethodInfo(out var methodInfo) ? methodInfo.Name : null);

                foreach (var version in versions)
                {
                    options.SwaggerDoc(version.Key, version.Value);
                }

                MapOption(options);
            });
        }

        public static void UseVersionedOpenApi(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
        }
    }
}