using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ValetaxTest.Application.Validators.Common;

namespace ValetaxTest.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(Inject).Assembly));
        
        services.AddValidatorsFromAssembly(typeof(Inject).Assembly);
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        return services;
    }
}