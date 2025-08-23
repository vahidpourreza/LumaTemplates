
using FluentValidation;
using Luma.Extensions.Translations.Abstractions;
using LumaTemplate.Core.Resources;

namespace LumaTemplate.Core.RequestResponse.Users.Queries.GetById;
public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator(ITranslator translator)
    {
        RuleFor(q => q.UserId)
            .GreaterThan(0).WithMessage(translator[ProjectValidationError.VALIDATION_ERROR_REQUIRED, ProjectTranslation.USER_ID]);
    }
}

