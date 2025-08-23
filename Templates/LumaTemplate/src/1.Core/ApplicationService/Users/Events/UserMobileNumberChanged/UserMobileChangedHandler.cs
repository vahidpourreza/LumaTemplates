
using Luma.Core.Contracts.ApplicationServices.Events;
using LumaTemplate.Core.Domain.Users.Events;
using Microsoft.Extensions.Logging;

namespace LumaTemplate.Core.ApplicationService.Users.Events.UserMobileNumberChanged;

public class UserMobileChangedHandler : IDomainEventHandler<UserMobileChanged>
{
    private readonly ILogger<UserMobileChangedHandler> _logger;

    public UserMobileChangedHandler(ILogger<UserMobileChangedHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(UserMobileChanged Event)
    {
        try
        {
            _logger.LogWarning("User : {UserBusinessId} changed their mobile number to : {NewMobileNumber} ", Event.UserBusinessId, Event.NewMobileNumber);

            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

}


