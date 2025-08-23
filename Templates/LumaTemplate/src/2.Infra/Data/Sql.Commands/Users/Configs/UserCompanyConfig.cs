using LumaTemplate.Core.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LumaTemplate.Infra.Data.Sql.Commands.Users.Configs;
public sealed class UserCompanyConfig : IEntityTypeConfiguration<UserCompany>
{
    public void Configure(EntityTypeBuilder<UserCompany> builder)
    {
        builder.Property(uc => uc.UserId)
               .IsRequired();

        builder.Property(uc => uc.CompanyId)
               .IsRequired();

    }
}

