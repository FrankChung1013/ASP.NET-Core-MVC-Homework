using FluentValidation;

namespace Homework_SkillTree.Api.Request.Validators;

public class UpdateAccountBookRequestValidator : AbstractValidator<UpdateAccountBookRequest>
{
    public UpdateAccountBookRequestValidator()
    {
        RuleFor(request => request.Id)
            .NotEmpty()
            .NotNull();
        RuleFor(request => request.Category)
            .IsInEnum();
        RuleFor(request => request.Money)
            .GreaterThan(0);
    }
}