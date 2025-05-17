using Homework_SkillTree.Domain.Common.Enums;
using Homework_SkillTree.Domain.Entities.DAO;

namespace Homework_SkillTree.Domain.Interfaces.Repository;

public interface IAccountBookRepository
{
    Task<List<AccountBook>> GetAccountBooksWithPaginationAsync(int pageNumber, int pageSize, AccountingCategoryEnum? categoryEnum);

    Task<int> GetAccountBooksCountAsync();

    Task<int> AddAsync(AccountBook accountBook);

    Task<int> UpdateAsync(AccountBook accountBook);
}