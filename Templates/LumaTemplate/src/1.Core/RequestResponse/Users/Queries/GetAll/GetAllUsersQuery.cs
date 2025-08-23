using Luma.Core.RequestResponse.Endpoints;
using Luma.Core.RequestResponse.Queries;

namespace LumaTemplate.Core.RequestResponse.Users.Queries.GetAll;

public class GetAllUsersQuery : IQuery<List<UserQuery>?>, IWebRequest
{
    public string Path => "/api/User/GetAll";
}


