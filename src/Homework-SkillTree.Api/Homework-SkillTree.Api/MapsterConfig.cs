using Homework_SkillTree.Domain.Common.Enums;
using Homework_SkillTree.Domain.Entities;
using Homework_SkillTree.Domain.Entities.DAO;
using Homework_SkillTree.Domain.Entities.DTO;
using Mapster;

namespace Homework_SkillTree.Api;

public static class MapsterConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<AccountBook, Accounting>.NewConfig()
            .Map(dest => dest.Category, src => ((AccountingCategoryEnum)src.Categoryyy).ToString())
            .Map(dest => dest.Money, src => src.Amounttt)
            .Map(dest => dest.Date, src => src.Dateee)
            .Map(dest => dest.Description, src => src.Remarkkk);
        
        TypeAdapterConfig<Accounting, AccountBook>.NewConfig()
            .Map(dest => dest.Categoryyy, src => (AccountingCategoryEnum)Enum.Parse(typeof(AccountingCategoryEnum), src.Category))
            .Map(dest => dest.Amounttt, src => src.Money)
            .Map(dest => dest.Dateee, src => src.Date)
            .Map(dest => dest.Remarkkk, src => src.Description);
    }
}