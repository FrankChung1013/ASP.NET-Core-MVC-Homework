using Homework_SkillTree.DBModels;

namespace Homework_SkillTree.Interfaces.Repositories;

public interface IHomeRepository
{
    Task<List<AccountBook>> GetAccountBooksWithPaginationAsync(int pageNumber, int pageSize);
}