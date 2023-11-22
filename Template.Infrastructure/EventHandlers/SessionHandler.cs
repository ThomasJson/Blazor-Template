using Template.Infrastructure.Storage;

namespace Template.Infrastructure.EventHandlers
{
    public static class SessionHandler
    {
        public static AccountSession GetSession(Dictionary<string, string> sessionDatas)
        {
            if (sessionDatas != null)
            {
                return new AccountSession
                {
                    UserName = sessionDatas["UserName"],
                    Role = sessionDatas["Role"]
                };
            }

            else { return null; }
        }
    }
}