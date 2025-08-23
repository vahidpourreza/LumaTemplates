namespace LumaTemplate.Infra.Data.Sql.Queries.Entities;

public partial class UserCompany
{
    public long Id { get; set; }
    public Guid BusinessId { get; set; }
    public long UserId { get; set; }
    public long CompanyId { get; set; }
    public virtual User User { get; set; } = null!;
}

