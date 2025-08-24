using Luma.Extensions.Events.Outbox.Dal.EF;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LumaTemplate.Infra.Data.Sql.Commands.Common;
public class DbContextNameCommandDbContext : BaseOutboxCommandDbContext
{
    #region DbSets


    #endregion

    public DbContextNameCommandDbContext(DbContextOptions<DbContextNameCommandDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

}
