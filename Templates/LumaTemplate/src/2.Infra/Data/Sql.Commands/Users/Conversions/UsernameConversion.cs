using LumaTemplate.Core.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LumaTemplate.Infra.Data.Sql.Commands.Users.Conversions;

public class UsernameConversion : ValueConverter<Username, string>
{
    public UsernameConversion()
        : base(
            v => v.Value,
            v => Username.FromString(v)
        )
    { }
}

