using Luma.Core.ApplicationServices.Commands;
using Luma.Core.RequestResponse.Commands;
using Luma.Utilities;
using LumaTemplate.Core.Contracts.Users.Commands;
using LumaTemplate.Core.Domain.Users.Entities;
using LumaTemplate.Core.Domain.Users.ValueObjects;
using LumaTemplate.Core.RequestResponse.Users.Commands.ChangeMobile;

namespace LumaTemplate.Core.ApplicationService.Users.Commands.ChangeMobile;

public class ChangeMobileCommandHandler : CommandHandler<ChangeMobileCommand>
{
    private readonly IUserCommandRepository _userCommandRepository;

    public ChangeMobileCommandHandler(LumaServices LumaServices, IUserCommandRepository userCommandRepository) : base(LumaServices)
    {
        _userCommandRepository = userCommandRepository;
    }

    public override async Task<CommandResult> Handle(ChangeMobileCommand command)
    {

        User user = await _userCommandRepository.GetGraphAsync(command.UserId);

        user.ChangeMobile(MobileNumber.FromString(command.NewMobileNumber));

        await _userCommandRepository.CommitAsync();

        return Ok();
    }
}

