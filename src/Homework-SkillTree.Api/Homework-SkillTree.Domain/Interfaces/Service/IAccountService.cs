using Homework_SkillTree.Domain.Common.Enums;
using Homework_SkillTree.Domain.Entities;
using Homework_SkillTree.Domain.Entities.DTO;

namespace Homework_SkillTree.Domain.Interfaces.Service;

public interface IAccountService
{
    Task<List<Accounting>> GetAccountBooksAsync(int pageNumber, int pageSize, AccountingCategoryEnum? categoryEnum);

    Task<object> GetAccountBooksCountAsync();

    Task<int> AddAccountBookAsync(Accounting accountBook);
    
    Task<int> UpdateAccountBookAsync(Accounting accountBook);
}