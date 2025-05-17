using Homework_SkillTree.Api.Context;
using Homework_SkillTree.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace Homework_SkillTree.Infrastructure.Repositories;

public class UnitOfWorkRepository(SkillTreeHomeworkDbContext context,
    IAccountBookRepository accountBookRepository) : IUnitOfWorkRepository
{
    public IAccountBookRepository AccountBookRepository { get; } = accountBookRepository;
    
    public Task<IDbContextTransaction> BeginTransactionAsync() => context.Database.BeginTransactionAsync();
    
    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
}