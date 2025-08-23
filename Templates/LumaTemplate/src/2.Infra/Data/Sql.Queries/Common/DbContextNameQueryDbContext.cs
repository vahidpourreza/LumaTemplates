using Luma.Infra.Data.Sql.Queries;
using LumaTemplate.Infra.Data.Sql.Queries.Entities;
using Microsoft.EntityFrameworkCore;

namespace LumaTemplate.Infra.Data.Sql.Queries.Common;

public class DbContextNameQueryDbContext : BaseQueryDbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserCompany> UserCompanies { get; set; }


    public DbContextNameQueryDbContext(DbContextOptions<DbContextNameQueryDbContext> options) : base(options)
    {
    }
}
