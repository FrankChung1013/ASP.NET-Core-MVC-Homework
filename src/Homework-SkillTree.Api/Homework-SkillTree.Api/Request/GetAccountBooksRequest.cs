using Homework_SkillTree.Domain.Common.Enums;

namespace Homework_SkillTree.Api.Request;

public class GetAccountBooksRequest
{
    /// <summary>
    /// 頁數
    /// </summary>
    public int PageNumber { get; set; }
    
    /// <summary>
    /// 單頁筆數
    /// </summary>
    public int PageSize { get; set; }
    
    /// <summary>
    /// 帳目類別
    /// </summary>
    public AccountingCategoryEnum? CategoryEnum { get; set; }
}