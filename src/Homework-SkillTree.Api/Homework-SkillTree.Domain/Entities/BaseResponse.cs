namespace Homework_SkillTree.Domain.Entities;

public class BaseResponse
{
    public object? Data { get; set; }

    public object? Message { get; set; }

    public bool Success { get; set; } = false;
}