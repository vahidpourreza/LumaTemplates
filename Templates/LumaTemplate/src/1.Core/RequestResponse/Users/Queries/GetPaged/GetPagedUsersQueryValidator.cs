
using FluentValidation;
using Luma.Extensions.Translations.Abstractions;
using LumaTemplate.Core.Resources;

namespace LumaTemplate.Core.RequestResponse.Users.Queries.GetPaged;


public class GetPagedUsersQueryValidator : AbstractValidator<GetPagedUsersQuery>
{
    public GetPagedUsersQueryValidator(ITranslator translator)
    {
        RuleFor(q => q.Username)
            .MaximumLength(ProjectConsts.USERNAME_MAX_LENGTH)
            .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_STRING_LENGTH_BETWEEN, ProjectTranslation.USERNAME, ProjectConsts.USERNAME_MIN_LENGTH.ToString(), ProjectConsts.USERNAME_MAX_LENGTH.ToString()]);

        RuleFor(q => q.Mobile)
            .Matches(@"^\+\d{10,15}$")
            .When(q => !string.IsNullOrEmpty(q.Mobile))
            .WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_INVALID_CHARACTERS, ProjectTranslation.MOBILE_NUMBER]);
    }
}
