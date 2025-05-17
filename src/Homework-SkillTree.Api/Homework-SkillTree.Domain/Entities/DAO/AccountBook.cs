namespace Homework_SkillTree.Domain.Entities.DAO;

public partial class AccountBook
{
    public Guid Id { get; set; }

    public int Categoryyy { get; set; }

    public int Amounttt { get; set; }

    public DateTime Dateee { get; set; }

    public string Remarkkk { get; set; } = null!;
}
