using Luma.Core.ApplicationServices.Queries;
using Luma.Core.RequestResponse.Queries;
using Luma.Utilities;
using LumaTemplate.Core.Contracts.Users.Queries;
using LumaTemplate.Core.RequestResponse.Users.Queries.GetById;
using LumaTemplate.Core.RequestResponse.Users.Queries;

namespace LumaTemplate.Core.ApplicationService.Users.Queries.GetById;
public class GetUserByIdQueryHandler : QueryHandler<GetUserByIdQuery, UserQuery?>
{
    private readonly IUserQueryRepository _userQueryRepository;

    public GetUserByIdQueryHandler(LumaServices LumaServices, IUserQueryRepository userQueryRepository) : base(LumaServices)
    {
        _userQueryRepository = userQueryRepository;
    }

    public override async Task<QueryResult<UserQuery?>> Handle(GetUserByIdQuery query)
    {
        var users = await _userQueryRepository.ExecuteAsync(query);

        return await ResultAsync(users);
    }
}
