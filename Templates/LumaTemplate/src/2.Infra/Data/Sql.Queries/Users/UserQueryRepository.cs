
using Luma.Core.RequestResponse.Queries;
using Luma.Infra.Data.Sql.Queries;
using LumaTemplate.Core.Contracts.Users.Queries;
using LumaTemplate.Core.RequestResponse.Users.Queries.GetAll;
using LumaTemplate.Core.RequestResponse.Users.Queries.GetById;
using LumaTemplate.Core.RequestResponse.Users.Queries.GetPaged;
using LumaTemplate.Core.RequestResponse.Users.Queries;
using LumaTemplate.Infra.Data.Sql.Queries.Common;
using Microsoft.EntityFrameworkCore;
using LumaTemplate.Infra.Data.Sql.Queries.Entities;

namespace LumaTemplate.Infra.Data.Sql.Queries.Users;

public class UserQueryRepository : BaseQueryRepository<DbContextNameQueryDbContext>, IUserQueryRepository
{
    public UserQueryRepository(DbContextNameQueryDbContext dbContext) : base(dbContext)
    {
    }

    public Task<List<UserQuery>?> ExecuteAsync(GetAllUsersQuery query)
    {
        return _dbContext.Users
            .Select(u => new UserQuery
            {
                Id = u.Id,
                Mobile = u.Mobile,
                Gender = u.Gender,
                UserCompanies = u.UserCompanies.Select(x => new UserCompanyQuery
                {
                    Id = x.Id,
                    CompanyId = x.CompanyId,
                    UserId = x.UserId

                }).ToList(),
            })
            .ToListAsync();
    }

    public Task<UserQuery?> ExecuteAsync(GetUserByIdQuery query)
    {
        return _dbContext.Users
            .Where(u => u.Id == query.UserId)
            .Select(u => new UserQuery
            {
                Id = u.Id,
                Username = u.Username,
                Mobile = u.Mobile,
                Gender = u.Gender,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<PagedData<UserQuery>> ExecuteAsync(GetPagedUsersQuery query)
    {
        var result = new PagedData<UserQuery>();

        IQueryable<User> users = _dbContext.Users;

        // Apply filters
        if (!string.IsNullOrWhiteSpace(query.Mobile))
            users = users.Where(c => c.Mobile == query.Mobile);

        if (!string.IsNullOrWhiteSpace(query.Username))
            users = users.Where(c => c.Username.Contains(query.Username));

        if (query.NeedTotalCount)
            result.TotalCount = await users.CountAsync();

        var pagedUsers = await users
            .OrderBy(c => c.Username)
            .Skip(query.SkipCount)
            .Take(query.PageSize)
            .Select(u => new UserQuery
            {
                Id = u.Id,
                Username = u.Username,
                Mobile = u.Mobile,
                Gender = u.Gender,
            })
            .ToListAsync();

        result.QueryResult = pagedUsers;

        return result;
    }

}
