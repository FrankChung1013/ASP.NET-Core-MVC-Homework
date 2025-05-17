using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Homework_SkillTree.Api.Request;

public class UpdateAccountBookRequest
{
    public Guid Id { get; set; } 
    
    public string Category { get; set; } = string.Empty;

    public int Money { get; set; }

    public string? Description { get; set; }
}