using Luma.Core.ApplicationServices.Commands;
using Luma.Core.Domain.Exceptions;
using Luma.Core.RequestResponse.Commands;
using Luma.Utilities;
using LumaTemplate.Core.ApplicationService.Users.Events.UserMobileNumberChanged;
using LumaTemplate.Core.Contracts.Users.Commands;
using LumaTemplate.Core.Domain.Users.Entities;
using LumaTemplate.Core.Domain.Users.Enums;
using LumaTemplate.Core.Domain.Users.ValueObjects;
using LumaTemplate.Core.RequestResponse.Users.Commands.Create;
using Microsoft.Extensions.Logging;

namespace LumaTemplate.Core.ApplicationService.Users.Commands.Create;

public class CreateUserCommandHandler : CommandHandler<CreateUserCommand, long>
{
    private readonly IUserCommandRepository _userCommandRepository;
    private readonly ILogger<CreateUserCommandHandler> _logger;
    public CreateUserCommandHandler(LumaServices LumaServices, IUserCommandRepository userCommandRepository) : base(LumaServices)
    {
        _userCommandRepository = userCommandRepository;
        _logger = LumaServices.LoggerFactory.CreateLogger<CreateUserCommandHandler>();

    }

    public override async Task<CommandResult<long>> Handle(CreateUserCommand command)
    {
        //????? ??? ??? ????? ???? ??? ??? ??? ??
        _logger.LogInformation("This is the sample LogInformation. im going to create a new user here.");
        _logger.LogDebug("This is the sample LogDebug. im going to create a new user here.");
        _logger.LogError("This is the sample LogError. im going to create a new user here.");
        _logger.LogCritical("This is the sample LogCritical. im going to create a new user here.");
        _logger.LogTrace("This is the sample LogTrace. im going to create a new user here.");
        _logger.LogWarning("This is the sample LogWarning. im going to create a new user here.");

        // convert gender
        if (!Enum.TryParse(command.Gender, out Gender gender))
            throw new InvalidEntityStateException("Invalid gender value.");

        var user = User.Create(Username.FromString(command.Username), MobileNumber.FromString(command.Mobile), gender);

        await _userCommandRepository.InsertAsync(user);
        await _userCommandRepository.CommitAsync();

        return Ok(user.Id);
    }
}

