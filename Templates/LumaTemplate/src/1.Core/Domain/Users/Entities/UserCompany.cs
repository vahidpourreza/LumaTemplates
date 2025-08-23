using Luma.Core.Domain.Entities;

namespace LumaTemplate.Core.Domain.Users.Entities;

public sealed class UserCompany : Entity
{

    #region Properties
    public long UserId { get; private set; }
    public long CompanyId { get; private set; }

    #endregion


    #region Constructors
    private UserCompany() { }

    private UserCompany(long userId, long companyId)
    {
        UserId = userId;
        CompanyId = companyId;
    }
    #endregion


    #region Commands and Factories
    public static UserCompany Create(long userId, long companyId)
    {
        var userCompany = new UserCompany(userId, companyId);

        return userCompany;
    }

    #endregion


}
