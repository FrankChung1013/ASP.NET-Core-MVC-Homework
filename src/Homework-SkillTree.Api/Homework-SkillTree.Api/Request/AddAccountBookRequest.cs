using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Homework_SkillTree.Api.Request;

public class AddAccountBookRequest
{
    public string Category { get; set; } = string.Empty;

    public int Money { get; set; }

    public string? Description { get; set; }
}