using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Homework_SkillTree.Api.Request;

public class AddAccountBookRequest
{
    /// <summary>
    /// 帳目類別
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// 金額
    /// </summary>
    public int Money { get; set; }

    /// <summary>
    /// 註記
    /// </summary>
    public string? Description { get; set; }
}