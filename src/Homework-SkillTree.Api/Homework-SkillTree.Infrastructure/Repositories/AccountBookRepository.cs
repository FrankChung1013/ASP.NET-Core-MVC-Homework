using Homework_SkillTree.Domain.Common.Enums;
using Homework_SkillTree.Domain.Entities.DAO;
using Homework_SkillTree.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Homework_SkillTree.Infrastructure.Repositories;

public class AccountBookRepository(IRepository<AccountBook> repository) : IAccountBookRepository
{
    public async Task<List<AccountBook>> GetAccountBooksWithPaginationAsync(int pageNumber, int pageSize, AccountingCategoryEnum? categoryEnum)
    {
        var query = repository.FindAsQueryable();
        if (categoryEnum.HasValue)
        {
            query = query.Where(account => account.Categoryyy == (int)categoryEnum);
        }

        query = query.OrderByDescending(account => account.Dateee);
        
        return await query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();
    }
        
    public async Task<int> GetAccountBooksCountAsync() => await repository.GetCountAsync();

    public async Task<int> AddAsync(AccountBook accountBook)
    {
        await repository.AddAsync(accountBook);
        return await repository.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(AccountBook accountBook)
    {
        repository.Update(accountBook);
        return await repository.SaveChangesAsync();
    }
}