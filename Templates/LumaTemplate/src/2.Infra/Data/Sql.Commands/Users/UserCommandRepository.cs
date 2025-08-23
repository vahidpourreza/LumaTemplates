using Luma.Infra.Data.Sql.Commands;
using LumaTemplate.Core.Contracts.Users.Commands;
using LumaTemplate.Core.Domain.Users.Entities;
using LumaTemplate.Infra.Data.Sql.Commands.Common;
using Microsoft.EntityFrameworkCore;

namespace LumaTemplate.Infra.Data.Sql.Commands.Users;

public class UserCommandRepository : BaseCommandRepository<User, DbContextNameCommandDbContext, long>, IUserCommandRepository
{
    public UserCommandRepository(DbContextNameCommandDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User> GetUserWithCompaniesAsync(long userId)
    {
        return await _dbContext.Users
            .Include(u => u.UserCompanies)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }
}



