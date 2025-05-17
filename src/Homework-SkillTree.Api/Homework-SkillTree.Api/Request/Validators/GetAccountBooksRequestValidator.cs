using FluentValidation;

namespace Homework_SkillTree.Api.Request.Validators;

public class GetAccountBooksRequestValidator : AbstractValidator<GetAccountBooksRequest>
{
    public GetAccountBooksRequestValidator()
    {
        RuleFor(request => request.PageNumber)
            .GreaterThanOrEqualTo(1);
        RuleFor(request => request.PageSize)
            .GreaterThanOrEqualTo(1);
        RuleFor(request => request.CategoryEnum)
            .IsInEnum();
    }
}