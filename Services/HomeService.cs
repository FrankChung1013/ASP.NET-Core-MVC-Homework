using Homework_SkillTree.Interfaces.Repositories;
using Homework_SkillTree.Interfaces.Services;
using Homework_SkillTree.Models;
using Mapster;
using MapsterMapper;

namespace Homework_SkillTree.Services;

public class HomeService(IHomeRepository repository, IMapper mapper, ILogger<HomeService> logger) : IHomeService
{
    public async Task<List<Accounting>> GetAccountBooksAsync(int pageNumber, int pageSize)
    {
        var accountBooks = await repository.GetAccountBooksWithPaginationAsync(pageNumber, pageSize);

        return mapper.Map<List<Accounting>>(accountBooks);
    }
}