using System.ComponentModel;
using Fabricdot.Authorization.Permissions;
using Fabricdot.WebApi.Endpoint;
using Microsoft.AspNetCore.Mvc;
using ProjectName.WebApi.Application.Queries.Permissions;
using ProjectName.WebApi.Authorization;

namespace ProjectName.WebApi.Endpoints.Permissions;

/// <summary>
///     Permission
/// </summary>
[DefaultAuthorize]
public class PermissionController : EndPointBase
{
    /// <summary>
    ///     list
    /// </summary>
    /// <returns></returns>
    [Description("list permission")]
    [HttpGet("list")]
    public async Task<ICollection<PermissionGroup>> ListAsync()
    {
        return await QueryProcessor.ProcessAsync(new GetPermissionGroupsQuery());
    }
}
