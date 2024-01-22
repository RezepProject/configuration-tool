using System.Security.Claims;
using System.Text.Json;

namespace ConfigurationTool.Utils;

public static class AuthenticationUtils
{
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

    public static async Task<string> RefreshToken(string jwt)
    {
        var identity = new ClaimsIdentity(ParseClaimsFromJwt(jwt), "jwt");
        var id = identity.FindFirst(claim => claim.Type == "sid")?.ToString();
        return await HttpUtils.Post<string>($"authentication/refresh-token/{id}", null, jwt);
    }
}