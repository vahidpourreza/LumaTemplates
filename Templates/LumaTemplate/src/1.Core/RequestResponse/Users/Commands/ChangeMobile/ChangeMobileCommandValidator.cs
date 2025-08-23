using FluentValidation;
using Luma.Extensions.Translations.Abstractions;
using LumaTemplate.Core.Resources;

namespace LumaTemplate.Core.RequestResponse.Users.Commands.ChangeMobile;
public class ChangeMobileCommandValidator : AbstractValidator<ChangeMobileCommand>
{
    public ChangeMobileCommandValidator(ITranslator translator)
    {
        RuleFor(c => c.UserId)
            .GreaterThan(0).WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_REQUIRED, ProjectTranslation.USER_ID]);

        RuleFor(c => c.NewMobileNumber)
            .NotEmpty().WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_REQUIRED, ProjectTranslation.MOBILE_NUMBER]);
    }
}
