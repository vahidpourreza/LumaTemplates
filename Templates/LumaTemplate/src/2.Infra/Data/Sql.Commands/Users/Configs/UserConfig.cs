using LumaTemplate.Core.Domain.Users.Entities;
using LumaTemplate.Infra.Data.Sql.Commands.Users.Conversions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LumaTemplate.Infra.Data.Sql.Commands.Users.Configs;

public sealed class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.Property(u => u.Username)
               .HasConversion<UsernameConversion>()
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(u => u.Mobile)
               .HasConversion<MobileNumberConversion>()
               .HasMaxLength(15)
               .IsRequired();

        builder.Property(u => u.Gender)
               .HasConversion<GenderConversion>()
               .IsRequired();


        // Relationships
        builder.HasMany(u => u.UserCompanies)
               .WithOne()
               .HasForeignKey(uc => uc.UserId)
               .OnDelete(DeleteBehavior.Cascade);

    }
}

