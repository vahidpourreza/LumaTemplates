using Luma.Core.Domain.Entities;
using Luma.Core.Domain.ValueObjects;
using LumaTemplate.Core.Domain.Users.Enums;
using LumaTemplate.Core.Domain.Users.Events;
using LumaTemplate.Core.Domain.Users.ValueObjects;

namespace LumaTemplate.Core.Domain.Users.Entities;

public sealed class User : AggregateRoot
{
    #region Properties
    public Username Username { get; private set; }
    public MobileNumber Mobile { get; private set; }
    public Gender Gender { get; private set; }

    public IReadOnlyList<UserCompany> UserCompanies => _userCompanies.ToList();
    private readonly List<UserCompany> _userCompanies = new();

    #endregion

    #region Constructors
    private User() { }

    private User(Username username, MobileNumber mobile, Gender gender)
    {
        Username = username;
        Mobile = mobile;
        Gender = gender;

        AddEvent(new UserJoined(BusinessId.Value, Mobile.ToString()));

    }
    #endregion

    #region Commands and Factories

    public static User Create(Username username, MobileNumber mobile, Gender gender)
    {
        return new(username, mobile, gender);
    }

    public void ChangeMobile(MobileNumber newMobile)
    {
        if (Mobile.Equals(newMobile)) return;

        Mobile = newMobile;

        AddEvent(new UserMobileChanged(BusinessId.Value, newMobile.Value));
    }

    public void RequestCompanyJoin(long companyId)
    {
        var userCompany = UserCompany.Create(Id, companyId);

        _userCompanies.Add(userCompany);

        AddEvent(new UserRequestedCompanyJoin(BusinessId.Value, companyId));
    }

    #endregion


}
