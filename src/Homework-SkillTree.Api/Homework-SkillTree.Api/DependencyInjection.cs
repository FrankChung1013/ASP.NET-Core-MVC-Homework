using Homework_SkillTree.Application.Services;
using Homework_SkillTree.Domain.Interfaces.Repository;
using Homework_SkillTree.Domain.Interfaces.Service;
using Homework_SkillTree.Infrastructure;
using Homework_SkillTree.Infrastructure.Repositories;

namespace Homework_SkillTree.Api;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IAccountBookRepository, AccountBookRepository>();
        services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
    }
}