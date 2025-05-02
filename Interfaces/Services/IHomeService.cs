using Homework_SkillTree.DBModels;
using Homework_SkillTree.Models;

namespace Homework_SkillTree.Interfaces.Services;

public interface IHomeService
{
    Task<List<Accounting>> GetAccountBooksAsync(int pageNumber, int pageSize);
}