
using Luma.Core.ApplicationServices.Queries;
using Luma.Core.RequestResponse.Queries;
using Luma.Utilities;
using LumaTemplate.Core.Contracts.Users.Queries;
using LumaTemplate.Core.RequestResponse.Users.Queries.GetAll;
using LumaTemplate.Core.RequestResponse.Users.Queries;

namespace LumaTemplate.Core.ApplicationService.Users.Queries.GetAll;
public class GetAllUsersQueryHandler : QueryHandler<GetAllUsersQuery, List<UserQuery>?>
{
    private readonly IUserQueryRepository _userQueryRepository;

    public GetAllUsersQueryHandler(LumaServices LumaServices, IUserQueryRepository userQueryRepository) : base(LumaServices)
    {
        _userQueryRepository = userQueryRepository;
    }

    public override async Task<QueryResult<List<UserQuery>?>> Handle(GetAllUsersQuery query)
    {
        var users = await _userQueryRepository.ExecuteAsync(query);

        return await ResultAsync(users);
    }
}

