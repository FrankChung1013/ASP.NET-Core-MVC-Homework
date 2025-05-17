namespace Homework_SkillTree.Domain.Entities.DTO;

public class Accounting
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Category { get; set; } = string.Empty;

    public int Money { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public string? Description { get; set; }
}