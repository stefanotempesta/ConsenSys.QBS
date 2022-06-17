using ConsenSys.QBS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ConsenSys.QBS.Web.Controllers;

public class ConsortiumManagementController : Controller
{
    private static readonly HttpClient httpClient = new ();
    private readonly QbsClient qbs = new (httpClient);

    private readonly Guid subscriptionId;
    private readonly string appName;
    private readonly string resourceGroup;
    private readonly string managedResourceGroup;
    private readonly string bearerToken;
    private readonly string location;

    public ConsortiumManagementController(IConfiguration configuration)
    {
        subscriptionId = Guid.Parse(configuration["QBS:SubscriptionId"]);
        appName = configuration["QBS:AppName"];
        resourceGroup = configuration["QBS:ResourceGroup"];
        managedResourceGroup = configuration["QBS:ManagedResourceGroup"];
        location = configuration["QBS:Location"];
        bearerToken = configuration["QBS:BearerToken"];

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
    }

    public async Task<IActionResult> Index()
    {
        var consortiums = await qbs.ListConsortiumsAsync(subscriptionId, location);
        var members = await qbs.ListMembersAsync(subscriptionId, resourceGroup, appName, includeDeleted: false, includeRemoved: false);

        var model = new QbsApiResponseModel
        {
            Consortiums = consortiums,
            ConsortiumMembers = members
        };

        return View(model);
    }

    public async Task<IActionResult> Invite()
    {
        var inviteRequest = new InviteCreateRequestBody
        {
            InviterEmail = "stefano.tempesta@consensys.net",
            InviteeSubscriptionId = Guid.Parse("fcb0cf94-e971-4830-8f75-17b1edc6f5b1"),
            ExpireInDays = 10,
            InviteeEmail = "stefano.tempesta@outlook.com",
            InviteeRole = "MEMBER"
        };
        var invite = await qbs.CreateInviteAsync(subscriptionId, resourceGroup, appName, inviteRequest);

        var model = new QbsApiResponseModel
        {
            Invite = invite
        };

        return View(model);
    }

    public async Task<IActionResult> Remove(string memberName)
    {
        await qbs.RemoveMemberAsync(subscriptionId, resourceGroup, appName, memberNameToRemove: memberName);

        return View();
    }
}
