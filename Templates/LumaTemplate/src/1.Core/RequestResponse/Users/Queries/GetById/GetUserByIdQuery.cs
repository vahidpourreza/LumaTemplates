
using Luma.Core.RequestResponse.Endpoints;
using Luma.Core.RequestResponse.Queries;

namespace LumaTemplate.Core.RequestResponse.Users.Queries.GetById;
public class GetUserByIdQuery : IQuery<UserQuery?>, IWebRequest
{
    public long UserId { get; set; }
    public string Path => "/api/User/GetById";
}
