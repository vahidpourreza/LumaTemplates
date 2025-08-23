using LumaTemplate.Core.Domain.Users.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LumaTemplate.Infra.Data.Sql.Commands.Users.Conversions;

public class GenderConversion : ValueConverter<Gender, byte>
{
    public GenderConversion()
        : base(
            v => (byte)v, // Convert Gender to byte
            v => (Gender)v // Convert byte to Gender
        )
    { }
}

