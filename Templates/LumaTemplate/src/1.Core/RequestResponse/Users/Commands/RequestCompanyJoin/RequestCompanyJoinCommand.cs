using Luma.Core.RequestResponse.Commands;
using Luma.Core.RequestResponse.Endpoints;

namespace LumaTemplate.Core.RequestResponse.Users.Commands.RequestCompanyJoin;

public class RequestCompanyJoinCommand : ICommand, IWebRequest
{
    public long UserId { get; set; }
    public long CompanyId { get; set; }

    public string Path => "/api/User/RequestCompanyJoin";
}

