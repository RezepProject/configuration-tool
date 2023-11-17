using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace ConfigurationTool;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // TODO: Get token from backend
        string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6InRlc3QiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiIyIiwiZXhwIjoxNzAwMjU1NDExLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUyNjAiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUyNjAifQ.MPEf5FTSYiC4Hs3Nxy22AgtoFhNLEUoGqVAM3byjJMM";

        AuthenticationState state;
        var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
        // var identity = new ClaimsIdentity();
        var user = new ClaimsPrincipal(identity);
        state = new AuthenticationState(user);

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }
    public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}