using Microsoft.AspNetCore.Authorization;

namespace ExpenseTrackerAPI.Auth0
{
    public class RbacHandler : AuthorizationHandler<RbacRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RbacRequirement requirement)
        {
            if (!context.User.HasClaim(x => x.Type == "permissions"))
            {
                return Task.CompletedTask;
            }

            var permission = context.User.FindFirst(x => x.Type == "permissions" && x.Value == requirement.Permission);
            if (permission == null)
            {
                return Task.CompletedTask;
            }

            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
