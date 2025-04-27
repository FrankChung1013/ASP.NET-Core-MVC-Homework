using System;
using System.Collections.Generic;

namespace Homework_SkillTree.DBModels;

public partial class Accounting
{
    public int Sn { get; set; }

    public int Category { get; set; }

    public int Money { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }
}
