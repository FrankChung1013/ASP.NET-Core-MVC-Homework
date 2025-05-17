using FluentValidation;

namespace Homework_SkillTree.Api.Request.Validators;

public class AddAccountBookRequestValidator : AbstractValidator<AddAccountBookRequest>
{
    public AddAccountBookRequestValidator()
    {
        RuleFor(request => request.Category)
            .IsInEnum();
        RuleFor(request => request.Money)
            .GreaterThan(0);
    }
}