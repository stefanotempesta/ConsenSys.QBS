using ConsenSys.QBS;
using System.Net.Http.Headers;

string bearerToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6ImpTMVhvMU9XRGpfNTJ2YndHTmd2UU8yVnpNYyJ9.eyJhdWQiOiI4Yzk4OTMwNy0yNDM5LTQwMmItODZlYi01OTAwYzYxMzJkZWUiLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vMTcyNTVmYjAtMzczYi00YTFhLWJkNDctZDIxMWFiODZkZjgxL3YyLjAiLCJpYXQiOjE2NTM2MDQ1MDcsIm5iZiI6MTY1MzYwNDUwNywiZXhwIjoxNjUzNjA5NTUyLCJhaW8iOiJBVlFBcS84VEFBQUE4eXNPZk1NeEh0MWZ4YmVZOUV4cE9XamlaM3pralJzWjZYeGZYbnhhL1lDdmJ3S3phSDlvWWw1M3BtQ3h5cWwzNmY3dy9ZMzZhT3VnN2lMdVowbHRTb1psZE44UmxuSGJNTVM5T0thUFpIQT0iLCJhenAiOiI4Yzk4OTMwNy0yNDM5LTQwMmItODZlYi01OTAwYzYxMzJkZWUiLCJhenBhY3IiOiIwIiwiZmFtaWx5X25hbWUiOiJUZW1wZXN0YSIsImdpdmVuX25hbWUiOiJTdGVmYW5vIiwiZ3JvdXBzIjpbIjY3NWIyZmRiLTI0NTMtNDA4MS04YjY2LTA5MTY4YWQyNjNjYiJdLCJuYW1lIjoiU3RlZmFubyBUZW1wZXN0YSIsIm9pZCI6ImI3MzFiMDkyLTMxODItNGQ5ZC05MGM2LTUxOWFlZDAwMTY4MSIsInByZWZlcnJlZF91c2VybmFtZSI6InN0ZWZhbm8udGVtcGVzdGFAY29uc2Vuc3lzLm5ldCIsInJoIjoiMC5BU1VBc0Y4bEZ6czNHa3E5UjlJUnE0YmZnUWVUbUl3NUpDdEFodXRaQU1ZVExlNGxBQkUuIiwic2NwIjoiVXNlci5SZWFkIiwic2lkIjoiODAxMjljMzMtZDI4MC00M2ZkLWE1ODAtZjYwZmQ0MWM0YzJkIiwic3ViIjoieWh2aUdHZ1BrSGkzYnltdTRWWVFtZ0E5cW1OWTUzR0JaaDc4ZXhXcXY3NCIsInRpZCI6IjE3MjU1ZmIwLTM3M2ItNGExYS1iZDQ3LWQyMTFhYjg2ZGY4MSIsInV0aSI6IkhPdlFDYlpUZzAydHYzM21nU2dEQUEiLCJ2ZXIiOiIyLjAifQ.RMudRFcSI31Tp9py4ecpJdWgMDlZm4bTWepfGnaO9WB_pPSXr_OyqbUKPj3sZsNaqgks1WTBWR87hWHJhIgcAV-rTeegt0EYZ90b3r08AY-tFQVaGfNQ4pPn4kDad4CiOdnhS7_vxQ6uz6QvmvM6i1oRNVvk9mm09SzHINgZxICFvkLyeG25eKx4nKAsVV5k84BD_7rHAssLjQ90TWJLZRMg2VMXIBGhPzb3r4Oxbu1b-9ATnwsS1-ul86RAjzg8lYTOajy7BrodUr_UmiShRpf9guUKeRS39AnOaYlP_5qtE4Ej0ey9EzsqqGTtpfcoTMUhZvhEq6ybIh9Ov0qmrw";

HttpClient httpClient = new();
httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

QbsClient qbs = new(httpClient);

Guid subscriptionId = Guid.Parse("060443b5-fa0a-4a86-b1d7-eee3c630e4e0");
string appName = "stqbspreviewapp";
string resourceGroup = "st-qbs-preview";
string location = "southeastasia";

Console.WriteLine("--- Consortiums ---");
var consortiums = await qbs.ListConsortiumsAsync(subscriptionId, location);
foreach(var c in consortiums.Value)
{
    Console.WriteLine(c.Name);
}

Console.WriteLine("--- Members ---");
var members = await qbs.ListMembersAsync(subscriptionId, resourceGroup, appName, includeDeleted: false, includeRemoved: false);
foreach (var m in members.Value)
{
    Console.WriteLine($"{m.Name}, role: {m.Role}, region: {m.Region}, created on: {m.CreatedDate}");
}

var inviteRequest = new InviteCreateRequestBody
{
    InviterEmail = "stefano.tempesta@consensys.net",
    InviteeSubscriptionId = Guid.Parse("fcb0cf94-e971-4830-8f75-17b1edc6f5b1"),
    ExpireInDays = 10,
    InviteeEmail = "stefano.tempesta@outlook.com",
    InviteeRole = "MEMBER"
};
var invite = await qbs.CreateInviteAsync(subscriptionId, resourceGroup, appName, inviteRequest);
Console.WriteLine($"Invite Code: {invite.InviteCode}");
