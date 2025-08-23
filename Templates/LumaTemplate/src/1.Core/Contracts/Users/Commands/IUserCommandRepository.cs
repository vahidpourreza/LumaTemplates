using Luma.Core.Contracts.Data.Commands;
using LumaTemplate.Core.Domain.Users.Entities;

namespace LumaTemplate.Core.Contracts.Users.Commands;

public interface IUserCommandRepository : ICommandRepository<User, long>
{
    Task<User> GetUserWithCompaniesAsync(long userId);
}
