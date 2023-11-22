using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Template.Infrastructure.Storage;
using System.Security.Claims;

namespace Template.Infrastructure.Services.Authentication
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

        public AuthStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                // await Task.Delay(2000); => To display Authorizing View

                var accountSessionStorageResult = await _sessionStorage.GetAsync<AccountSession>("AccountSession");
                var accountSession = accountSessionStorageResult.Success ? accountSessionStorageResult.Value : null;
                if (accountSession == null)
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, accountSession.UserName),
                    new Claim(ClaimTypes.Role, accountSession.Role)
                }, "CustomAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }

            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }

        public async Task UpdateAuthenticationState(AccountSession accountSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if (accountSession != null)
            {
                await _sessionStorage.SetAsync("AccountSession", accountSession);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, accountSession.UserName),
                    new Claim(ClaimTypes.Role, accountSession.Role)
                }));
            }
            else
            {
                await _sessionStorage.DeleteAsync("AccountSession");
                claimsPrincipal = _anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}