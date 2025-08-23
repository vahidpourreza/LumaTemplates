namespace LumaTemplate.Infra.Data.Sql.Queries.Entities;

public class User
{
    public long Id { get; set; }
    public Guid BusinessId { get; set; }
    public string Username { get; set; } = null!;
    public string Mobile { get; set; } = null!;
    public byte Gender { get; set; }
    public virtual ICollection<UserCompany> UserCompanies { get; set; } = new List<UserCompany>();
}

