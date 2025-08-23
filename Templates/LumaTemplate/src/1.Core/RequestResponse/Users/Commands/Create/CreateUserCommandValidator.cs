using FluentValidation;
using Luma.Extensions.Translations.Abstractions;
using LumaTemplate.Core.Resources;

namespace LumaTemplate.Core.RequestResponse.Users.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator(ITranslator translator)
    {
        RuleFor(c => c.Username)
            .NotEmpty().WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_REQUIRED, ProjectTranslation.USERNAME])
            .MinimumLength(ProjectConsts.USERNAME_MIN_LENGTH)
            .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_STRING_LENGTH_BETWEEN, ProjectTranslation.USERNAME, ProjectConsts.USERNAME_MIN_LENGTH.ToString(), ProjectConsts.USERNAME_MAX_LENGTH.ToString()])
            .MaximumLength(ProjectConsts.USERNAME_MAX_LENGTH)
            .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_STRING_LENGTH_BETWEEN, ProjectTranslation.USERNAME, ProjectConsts.USERNAME_MIN_LENGTH.ToString(), ProjectConsts.USERNAME_MAX_LENGTH.ToString()]);

        RuleFor(c => c.Mobile)
            .NotEmpty().WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_REQUIRED, ProjectTranslation.MOBILE_NUMBER]);

        RuleFor(c => c.Gender)
            .NotEmpty().WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_REQUIRED, ProjectTranslation.Gender])
            .Must(g => g == "Male" || g == "Female" || g == "Other")
            .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_NOT_VALID, ProjectTranslation.Gender]);
    }
}

