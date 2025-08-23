using LumaTemplate.Core.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LumaTemplate.Infra.Data.Sql.Commands.Users.Conversions;

public class MobileNumberConversion : ValueConverter<MobileNumber, string>
{
    public MobileNumberConversion()
        : base(
            v => v.Value, // Convert MobileNumber to string
            v => MobileNumber.FromString(v) // Convert string to MobileNumber
        )
    { }
}

