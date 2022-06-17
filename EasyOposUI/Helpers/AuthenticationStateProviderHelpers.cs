using Microsoft.AspNetCore.Components.Authorization;

namespace EasyOposUI.Helpers
{
    public static class AuthenticationStateProviderHelpers
    {
        public static async Task<UserModel> GetUserFromAuth(this AuthenticationStateProvider provider, IUserData userData)
        {
            var authState = await provider.GetAuthenticationStateAsync();
            var authUser = authState.User;
            string objectId = authUser.Claims.FirstOrDefault(c => c.Type.Contains("objectidentifier"))?.Value;
            return await userData.GetUserFromAuthentication(objectId);
        }
    }
}
