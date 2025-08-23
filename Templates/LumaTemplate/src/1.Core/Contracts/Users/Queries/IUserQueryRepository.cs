using Luma.Core.Contracts.Data.Queries;
using Luma.Core.RequestResponse.Queries;
using LumaTemplate.Core.RequestResponse.Users.Queries;
using LumaTemplate.Core.RequestResponse.Users.Queries.GetAll;
using LumaTemplate.Core.RequestResponse.Users.Queries.GetById;
using LumaTemplate.Core.RequestResponse.Users.Queries.GetPaged;

namespace LumaTemplate.Core.Contracts.Users.Queries;

public interface IUserQueryRepository : IQueryRepository
{
    Task<List<UserQuery>?> ExecuteAsync(GetAllUsersQuery query);
    Task<UserQuery?> ExecuteAsync(GetUserByIdQuery query);
    Task<PagedData<UserQuery>> ExecuteAsync(GetPagedUsersQuery query);
}
