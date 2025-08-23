using Luma.Core.RequestResponse.Commands;
using Luma.Core.RequestResponse.Endpoints;

namespace LumaTemplate.Core.RequestResponse.Users.Commands.Create;

public class CreateUserCommand : ICommand<long>, IWebRequest
{
    public string Username { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;

    public string Path => "/api/User/Create";
}


