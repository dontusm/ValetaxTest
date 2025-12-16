using Microsoft.OpenApi.Models;

namespace ValetaxTest.Api;

public static class Inject
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ValetaxTest API",
                Version = "v1"
            });
        });
        
        return services;
    }
}