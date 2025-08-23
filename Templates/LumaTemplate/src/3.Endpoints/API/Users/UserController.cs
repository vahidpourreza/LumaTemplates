using Asp.Versioning;
using Luma.Core.RequestResponse.Queries;
using Luma.EndPoints.Web.Controllers;
using LumaTemplate.Core.RequestResponse.Users.Commands.ChangeMobile;
using LumaTemplate.Core.RequestResponse.Users.Commands.Create;
using LumaTemplate.Core.RequestResponse.Users.Commands.RequestCompanyJoin;
using LumaTemplate.Core.RequestResponse.Users.Queries;
using LumaTemplate.Core.RequestResponse.Users.Queries.GetAll;
using LumaTemplate.Core.RequestResponse.Users.Queries.GetById;
using LumaTemplate.Core.RequestResponse.Users.Queries.GetPaged;
using Microsoft.AspNetCore.Mvc;

namespace LumaTemplate.Endpoints.API.Users;


[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0", Deprecated = true)] // Mark API v1 as deprecated
[ApiVersion("2.0")]
public class UserController : BaseController
{
    #region Commands

    [HttpPost("Create")]
    [MapToApiVersion("1.0")]
    [Obsolete("This version is deprecated. Please use v2.", false)]
    public  IActionResult CreateUserV1([FromBody] CreateUserCommand command)
    {
        return Ok(new
        {
            Message = "This is v1 CreateUser response",
            UserId = 12345, // Example dummy ID
            Status = "User created successfully"
        });
    }

    [HttpPost("Create")]
    [MapToApiVersion("2.0")]
    public async Task<IActionResult> CreateUserV2([FromBody] CreateUserCommand command) => await Create<CreateUserCommand, long>(command);
   

    [HttpPut("ChangeMobile")]
    public async Task<IActionResult> ChangeUserMobileNumber([FromBody] ChangeMobileCommand command)
        => await Edit(command);

    [HttpPost("RequestCompanyJoin")]
    public async Task<IActionResult> RequestCompanyJoin([FromBody] RequestCompanyJoinCommand command)
        => await Edit(command);

    #endregion

    #region Queries

    [HttpGet("GetById")]
    [MapToApiVersion("1.0")]
    [Obsolete("This version is deprecated. Please use v2.", false)]
    public async Task<IActionResult> GetUserByIdV1([FromQuery] GetUserByIdQuery query)
    {
        Response.Headers.Add("Warning", "299 - \"API v1 of GetUserById is deprecated. Use v2.\"");
        return Ok(new
        {
            Message = "This is a v1 response",
            UserId = query.UserId,
            Name = "Dummy User v1"
        });
    }

    [HttpGet("GetById")]
    [MapToApiVersion("2.0")]
    public async Task<IActionResult> GetUserByIdV2([FromQuery] GetUserByIdQuery query) => await Query<GetUserByIdQuery, UserQuery?>(query);

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllUsers()
        => await Query<GetAllUsersQuery, List<UserQuery>?>(new GetAllUsersQuery());

    [HttpGet("GetPaged")]
    public async Task<IActionResult> GetPagedUsers([FromQuery] GetPagedUsersQuery query)
        => await Query<GetPagedUsersQuery, PagedData<UserQuery>>(query);

    #endregion

    #region Methods

    [HttpGet("/Clear")]
    public bool Clear()
    {
        GC.Collect(2);
        return true;
    }

    #endregion
}

