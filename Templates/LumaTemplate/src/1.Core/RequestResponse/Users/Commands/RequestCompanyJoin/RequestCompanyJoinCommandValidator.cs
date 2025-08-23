using FluentValidation;
using Luma.Extensions.Translations.Abstractions;
using LumaTemplate.Core.Resources;

namespace LumaTemplate.Core.RequestResponse.Users.Commands.RequestCompanyJoin;

public class RequestCompanyJoinCommandValidator : AbstractValidator<RequestCompanyJoinCommand>
{
    public RequestCompanyJoinCommandValidator(ITranslator translator)
    {
        RuleFor(c => c.UserId)
            .GreaterThan(0).WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_REQUIRED, ProjectTranslation.USER_ID]);

        RuleFor(c => c.CompanyId)
            .GreaterThan(0).WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_REQUIRED, ProjectTranslation.COMPANY_ID]);
    }
}
