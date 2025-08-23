
using Luma.Core.ApplicationServices.Queries;
using Luma.Core.RequestResponse.Queries;
using Luma.Utilities;
using LumaTemplate.Core.Contracts.Users.Queries;
using LumaTemplate.Core.RequestResponse.Users.Queries.GetPaged;
using LumaTemplate.Core.RequestResponse.Users.Queries;

namespace LumaTemplate.Core.ApplicationService.Users.Queries.GetPaged
{
    public class GetPagedUsersQueryHandler : QueryHandler<GetPagedUsersQuery, PagedData<UserQuery>>
    {

        private readonly IUserQueryRepository _userQueryRepository;

        public GetPagedUsersQueryHandler(LumaServices LumaServices, IUserQueryRepository userQueryRepository) : base(LumaServices)
        {
            _userQueryRepository = userQueryRepository;
        }

        public override async Task<QueryResult<PagedData<UserQuery>>> Handle(GetPagedUsersQuery query)
        {
            var users = await _userQueryRepository.ExecuteAsync(query);

            return await ResultAsync(users);
        }
    }
}


