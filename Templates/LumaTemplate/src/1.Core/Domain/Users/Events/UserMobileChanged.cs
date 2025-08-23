using Luma.Core.Domain.Events;

namespace LumaTemplate.Core.Domain.Users.Events;
public record UserMobileChanged(Guid UserBusinessId, string NewMobileNumber) : IDomainEvent;

