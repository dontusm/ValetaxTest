using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ValetaxTest.Application.Interfaces;
using ValetaxTest.Domain.Interfaces;
using ValetaxTest.Infrastructure.Data;
using ValetaxTest.Infrastructure.Repositories;
using ValetaxTest.Infrastructure.Writers;

namespace ValetaxTest.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped<IJournalWriter, JournalWriter>();
        
        services.AddScoped<ITreeRepository, TreeRepository>();
        services.AddScoped<INodeRepository, NodeRepository>();
        services.AddScoped<IJournalRepository, JournalRepository>();
        
        return services;
    }
}