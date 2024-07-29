using Template.Infrastructure.Storage;

namespace Template.Infrastructure.EventHandlers
{
    public static class SessionHandler
    {
        public static AccountSession AssignDataToCurrentSession(string UserName, string RoleName)
        {
            
            return new AccountSession
            {
                UserName = UserName,
                Role = RoleName
            };
            
        }
    }
}