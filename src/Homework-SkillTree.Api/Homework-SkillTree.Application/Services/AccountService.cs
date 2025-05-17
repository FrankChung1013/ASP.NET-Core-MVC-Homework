using Homework_SkillTree.Domain.Common.Enums;
using Homework_SkillTree.Domain.Entities.DAO;
using Homework_SkillTree.Domain.Entities.DTO;
using Homework_SkillTree.Domain.Interfaces.Repository;
using Homework_SkillTree.Domain.Interfaces.Service;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace Homework_SkillTree.Application.Services;

public class AccountService(IUnitOfWorkRepository unitOfWork, IMapper mapper, ILogger<AccountService> logger) : IAccountService
{
    public async Task<List<Accounting>> GetAccountBooksAsync(int pageNumber, int pageSize, AccountingCategoryEnum? categoryEnum)
    {
        var accountBooks = await unitOfWork.AccountBookRepository.GetAccountBooksWithPaginationAsync(pageNumber, pageSize, categoryEnum);

        return mapper.Map<List<Accounting>>(accountBooks);
    }
    
    public async Task<object> GetAccountBooksCountAsync() =>
        await unitOfWork.AccountBookRepository.GetAccountBooksCountAsync();

    public async Task<int> AddAccountBookAsync(Accounting accountBook)
    {
        await using var transaction = await unitOfWork.BeginTransactionAsync();
        var result = await unitOfWork.AccountBookRepository.AddAsync(mapper.Map<AccountBook>(accountBook));
        await transaction.CommitAsync();
        
        return result;
    }

    public async Task<int> UpdateAccountBookAsync(Accounting accountBook)
    {
        await using var transaction = await unitOfWork.BeginTransactionAsync();
        var result = await unitOfWork.AccountBookRepository.UpdateAsync(mapper.Map<AccountBook>(accountBook));
        await transaction.CommitAsync();
        
        return result;
    }
}