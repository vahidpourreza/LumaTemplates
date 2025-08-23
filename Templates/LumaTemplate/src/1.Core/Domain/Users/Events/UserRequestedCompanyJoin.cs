using Luma.Core.Domain.Events;

namespace LumaTemplate.Core.Domain.Users.Events;

public record UserRequestedCompanyJoin(Guid UserBusinessId, long CompanyId) : IDomainEvent;
