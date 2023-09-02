﻿using Microsoft.AspNetCore.Authorization;

namespace ExpenseTrackerAPI.Auth0
{
    public class RbacRequirement : IAuthorizationRequirement
    {
        public string Permission { get; set; }
        public RbacRequirement(string permission)
        {
            Permission = permission ?? throw new ArgumentNullException(nameof(permission));
        }
    }
}
