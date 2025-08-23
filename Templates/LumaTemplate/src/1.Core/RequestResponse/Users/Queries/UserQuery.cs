namespace LumaTemplate.Core.RequestResponse.Users.Queries;

public class UserQuery
{
    public long Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public byte Gender { get; set; }

    public List<UserCompanyQuery> UserCompanies  { get; set; }
}

