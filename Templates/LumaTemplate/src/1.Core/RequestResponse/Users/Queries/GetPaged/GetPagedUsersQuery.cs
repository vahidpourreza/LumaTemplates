using Luma.Core.RequestResponse.Endpoints;
using Luma.Core.RequestResponse.Queries;

namespace LumaTemplate.Core.RequestResponse.Users.Queries.GetPaged;

public class GetPagedUsersQuery : PageQuery<PagedData<UserQuery>>, IWebRequest
{
    public string Username { get; set; }
    public string Mobile { get; set; }


    public string Path => "/api/User/GetPaged";
}


