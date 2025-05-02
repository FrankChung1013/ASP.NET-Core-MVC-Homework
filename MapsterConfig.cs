using Homework_SkillTree.DBModels;
using Homework_SkillTree.Models;
using Mapster;

namespace Homework_SkillTree;

public static class MapsterConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<AccountBook, Accounting>.NewConfig()
            .Map(dest => dest.Category, src => src.Categoryyy)
            .Map(dest => dest.Money, src => src.Amounttt)
            .Map(dest => dest.Date, src => src.Dateee)
            .Map(dest => dest.Description, src => src.Remarkkk);
    }
    
}