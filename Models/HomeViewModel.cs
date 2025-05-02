using System.ComponentModel.DataAnnotations;
using Homework_SkillTree.Commons.Enums;
using Homework_SkillTree.DBModels;

namespace Homework_SkillTree.Models;

public class HomeViewModel
{
    public HomeDataModel Input { get; set; } = new();

    public List<Accounting> HomeDataModels { get; set; } = [];
    public int CurrentPage { get; set; } = 1;
    public int TotalPages { get; set; } = 0;
}

public class HomeDataModel
{
    /// <summary>
    /// 支出類別
    /// </summary>
    [Required(ErrorMessage = "請選擇類別")]
    [Range(0, 1)]
    public AccountingCategoryEnum? Category { get; set; }

    /// <summary>
    /// 金額
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "金額輸入錯誤")]
    [Required(ErrorMessage = "請輸入金額")]
    public int? Money { get; set; }

    /// <summary>
    /// 紀錄日期
    /// </summary>
    [Required(ErrorMessage = "請輸入日期")]
    [DataType(DataType.Date, ErrorMessage = "日期格式錯誤")]
    public DateTime? Date { get; set; }

    /// <summary>
    /// 備註
    /// </summary>
    [StringLength(1000, ErrorMessage = "備註不可超過1000字")]
    public string? Description { get; set; }
}

/// <summary>
/// 原本使用的EF的Model，因為老師表示作業不可改變資料結構，所以拿過來使用
/// </summary>
public class Accounting
{
    public int Category { get; set; }

    public int Money { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }
}