using Luma.Core.Domain.Exceptions;
using Luma.Core.Domain.ValueObjects;
using LumaTemplate.Core.Resources;
using System.Text.RegularExpressions;

namespace LumaTemplate.Core.Domain.Users.ValueObjects;

public class Username : BaseValueObject<Username>
{
    #region Constants

    #endregion

    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static Username FromString(string value) => new Username(value);

    private Username(string value)
    {


        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidValueObjectStateException(ProjectValidationError.VALIDATION_ERROR_REQUIRED, ProjectTranslation.USERNAME);

        value = value.Trim();

        if (value.Length < ProjectConsts.USERNAME_MIN_LENGTH || value.Length > ProjectConsts.USERNAME_MAX_LENGTH)
            throw new InvalidValueObjectStateException(
                                                     ProjectValidationError.VALIDATION_ERROR_STRING_LENGTH_BETWEEN,
                                                     ProjectTranslation.USERNAME,
                                                     ProjectConsts.USERNAME_MIN_LENGTH.ToString(),
                                                     ProjectConsts.USERNAME_MAX_LENGTH.ToString()
            );

        // Validate allowed characters:
        // - Only letters (a-z, A-Z), numbers (0-9), underscores (_), hyphens (-), and periods (.) are allowed.
        // - No other special characters (e.g., @, #, $, etc.) are permitted.
        if (!Regex.IsMatch(value, @"^[a-zA-Z0-9_.-]+$"))
            throw new InvalidValueObjectStateException(ProjectValidationError.VALIDATION_ERROR_INVALID_CHARACTERS, ProjectTranslation.USERNAME);

        // Validate no leading or trailing special characters:
        // - Usernames cannot start or end with a period (.), hyphen (-), or underscore (_).
        if (value.StartsWith(".") || value.StartsWith("-") || value.StartsWith("_") || value.EndsWith(".") || value.EndsWith("-") || value.EndsWith("_"))
            throw new InvalidValueObjectStateException(ProjectValidationError.VALIDATION_ERROR_LEADING_TRAILING_CHARACTERS, ProjectTranslation.USERNAME);


        // Validate reserved words:
        // - Usernames cannot match any of the reserved words (case-insensitive).
        if (ReservedWords.Contains(value))
            throw new InvalidValueObjectStateException(ProjectValidationError.VALIDATION_ERROR_RESERVED_WORD, ProjectTranslation.USERNAME);

        // Convert the username to lowercase to ensure case insensitivity:
        // - This ensures that "JohnDoe" and "johndoe" are treated as the same username.
        Value = value.ToLower();
    }

    private Username() { }
    #endregion

    #region Reserved Words
    // List of reserved usernames that are not allowed
    private static readonly HashSet<string> ReservedWords = new(StringComparer.OrdinalIgnoreCase)
    {
        "admin",
        "root",
        "moderator",
        "administrator",
        "system",
        "support",
        "test",
        "user",
    };
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(Username username) => username.Value;
    public static implicit operator Username(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;
    #endregion
}
