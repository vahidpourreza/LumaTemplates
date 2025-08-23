using Luma.Core.Domain.Exceptions;
using Luma.Core.Domain.ValueObjects;
using LumaTemplate.Core.Resources;
using System.Text.RegularExpressions;

public class MobileNumber : BaseValueObject<MobileNumber>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static MobileNumber FromString(string value) => new MobileNumber(value);

    private MobileNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidValueObjectStateException(ProjectValidationError.VALIDATION_ERROR_REQUIRED, ProjectTranslation.MOBILE_NUMBER);

        value = value.Trim();

        if (value.Length < ProjectConsts.Mobile_Number_MIN_LENGTH || value.Length > ProjectConsts.Mobile_Number_MAX_LENGTH)

            throw new InvalidValueObjectStateException(ProjectValidationError.VALIDATION_ERROR_STRING_LENGTH_BETWEEN,
                                                       ProjectTranslation.MOBILE_NUMBER,
                                                       ProjectConsts.Mobile_Number_MIN_LENGTH.ToString(),
                                                       ProjectConsts.Mobile_Number_MAX_LENGTH.ToString()
            );


        if (!IsValidMobileNumber(value))
            throw new InvalidValueObjectStateException(ProjectValidationError.VALIDATION_ERROR_NOT_VALID, ProjectTranslation.MOBILE_NUMBER);


        Value = value;
    }

    private MobileNumber() { }
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(MobileNumber mobileNumber) => mobileNumber.Value;
    public static implicit operator MobileNumber(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;

    private static bool IsValidMobileNumber(string mobileNumber)
    {
        // Regular expression for validating mobile numbers
        // Supports:
        // - International format (e.g., +989121234567)
        // - Local format (e.g., 09121234567)
        const string mobileRegex = @"^\+?[0-9]{10,15}$";
        return Regex.IsMatch(mobileNumber, mobileRegex);
    }
    #endregion
}
