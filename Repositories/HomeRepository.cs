using Homework_SkillTree.DBModels;
using Homework_SkillTree.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Homework_SkillTree.Repositories;

public class HomeRepository(IRepository<AccountBook> repository) : IHomeRepository
{
    public async Task<List<AccountBook>> GetAccountBooksWithPaginationAsync(int pageNumber, int pageSize) =>
        await repository.FindAsQueryable().Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();
    
    public async Task<int> GetAccountBooksCountAsync() => await repository.GetCountAsync();
}