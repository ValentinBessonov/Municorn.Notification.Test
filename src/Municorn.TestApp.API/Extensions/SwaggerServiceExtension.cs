using System.Reflection;

namespace Municorn.TestApp.Extensions;

public static class SwaggerServiceExtension
{
    public static IServiceCollection AddOwnSwaggerGen(this IServiceCollection services)
    {
        return services.AddSwaggerGen(c =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
    }
}
