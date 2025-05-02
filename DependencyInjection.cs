using Homework_SkillTree.Interfaces.Repositories;
using Homework_SkillTree.Interfaces.Services;
using Homework_SkillTree.Repositories;
using Homework_SkillTree.Services;
using MapsterMapper;

namespace Homework_SkillTree;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IHomeService, HomeService>();
        
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IHomeRepository, HomeRepository>();
        
    }
}