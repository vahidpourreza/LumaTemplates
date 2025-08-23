using Luma.Infra.Data.Sql.Commands;
using LumaTemplate.Core.Contracts.Common;

namespace LumaTemplate.Infra.Data.Sql.Commands.Common;

public class LumaTemplateUnitOfWork : BaseEntityFrameworkUnitOfWork<DbContextNameCommandDbContext>, ILumaTemplateUnitOfWork
{
    public LumaTemplateUnitOfWork(DbContextNameCommandDbContext dbContext) : base(dbContext)
    {
    }
}

