using Microsoft.AspNetCore.Authorization;

namespace ExpenseTracker.Model
{
    public class SessionRequirement : IAuthorizationRequirement
    {
        public string RequiredSessionKey { get; }

        public SessionRequirement(string requiredSessionKey)
        {
            RequiredSessionKey = requiredSessionKey;
        }
    }
}
