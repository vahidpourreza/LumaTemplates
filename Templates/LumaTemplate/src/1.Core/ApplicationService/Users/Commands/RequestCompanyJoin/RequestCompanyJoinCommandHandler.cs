using Luma.Core.ApplicationServices.Commands;
using Luma.Core.RequestResponse.Commands;
using Luma.Utilities;
using LumaTemplate.Core.Contracts.Users.Commands;
using LumaTemplate.Core.Domain.Users.Entities;
using LumaTemplate.Core.RequestResponse.Users.Commands.RequestCompanyJoin;

namespace LumaTemplate.Core.ApplicationService.Users.Commands.RequestCompanyJoin;

public class RequestCompanyJoinCommandHandler : CommandHandler<RequestCompanyJoinCommand>
{
    private readonly IUserCommandRepository _userCommandRepository;

    public RequestCompanyJoinCommandHandler(LumaServices LumaServices, IUserCommandRepository userCommandRepository) : base(LumaServices)
    {
        _userCommandRepository = userCommandRepository;
    }

    public override async Task<CommandResult> Handle(RequestCompanyJoinCommand command)
    {
        // Fetch user along with their associated companies not whole aggregate graph.
        User user = await _userCommandRepository.GetUserWithCompaniesAsync(command.UserId);

        user.RequestCompanyJoin(command.CompanyId);

        await _userCommandRepository.CommitAsync();

        return Ok();
    }

}
