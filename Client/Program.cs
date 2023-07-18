using IdentityModel.Client;
using System.Net.Http.Headers;

var api1TokenClient = new HttpClient();
var api1TokenResult = await api1TokenClient.RequestPasswordTokenAsync(new PasswordTokenRequest
{
    Address = "https://localhost:5001/connect/token",
    GrantType = "resource_owner_password",
    ClientId = "ROPClient",
    ClientSecret = "secret",
    UserName = "username",
    Password = "password",
    Scope = "api1.read",
});

var api1Client = new HttpClient();
api1Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", api1TokenResult.AccessToken);
var result1 = await api1Client.GetAsync("https://localhost:5002/api1/weatherforecast");



var api2TokenClient = new HttpClient();
var api2TokenResult = await api2TokenClient.RequestPasswordTokenAsync(new PasswordTokenRequest
{
    Address = "https://localhost:5001/connect/token",
    GrantType = "resource_owner_password",
    ClientId = "ROPClient",
    ClientSecret = "secret",
    UserName = "username",
    Password = "password",
    Scope = "api2.read",
});

var api2Client = new HttpClient();
api2Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", api2TokenResult.AccessToken);
var result2 = await api2Client.GetAsync("https://localhost:5002/api2/weatherforecast2");



Console.WriteLine("\n\n");