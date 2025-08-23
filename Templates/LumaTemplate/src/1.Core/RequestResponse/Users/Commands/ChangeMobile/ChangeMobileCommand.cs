using Luma.Core.RequestResponse.Commands;
using Luma.Core.RequestResponse.Endpoints;

namespace LumaTemplate.Core.RequestResponse.Users.Commands.ChangeMobile;

public class ChangeMobileCommand : ICommand, IWebRequest
{
    public long UserId { get; set; }
    public string NewMobileNumber { get; set; } = string.Empty;

    public string Path => "/api/User/ChangeMobile";
}
