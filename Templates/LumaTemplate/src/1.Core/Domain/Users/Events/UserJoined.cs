using Luma.Core.Domain.Events;

namespace LumaTemplate.Core.Domain.Users.Events;

public record UserJoined(Guid UserBusinessId, string mobileNumber) : IDomainEvent;

