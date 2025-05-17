using Microsoft.EntityFrameworkCore.Storage;

namespace Homework_SkillTree.Domain.Interfaces.Repository;

public interface IUnitOfWorkRepository
{
    public IAccountBookRepository AccountBookRepository { get; }
    
    Task<IDbContextTransaction> BeginTransactionAsync();
    
    Task<int> SaveChangesAsync();
}