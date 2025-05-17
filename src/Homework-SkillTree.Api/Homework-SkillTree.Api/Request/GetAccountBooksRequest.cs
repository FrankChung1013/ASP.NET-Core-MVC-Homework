using Homework_SkillTree.Domain.Common.Enums;

namespace Homework_SkillTree.Api.Request;

public class GetAccountBooksRequest
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public AccountingCategoryEnum? CategoryEnum { get; set; }
}