using System.Security.Claims;
using System.Text;
using System.Text.Json;
using ConfigurationTool.Utils;

namespace ConfigurationTool;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // TODO: use user from local storage
        // TODO: check if token is valid
        string? token = await HttpUtils.Post<string>("authentication", new  { UserIdentificator = "test", Password = "test" });

        if (token == null)
        {
            // TODO: handle
        }

        AuthenticationState state;
        var identity = new ClaimsIdentity(AuthenticationUtils.ParseClaimsFromJwt(token), "jwt");
        // var identity = new ClaimsIdentity();
        var user = new ClaimsPrincipal(identity);
        state = new AuthenticationState(user);

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }

}