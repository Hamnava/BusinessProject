using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessProject.DataModelLayer.Entities
{
    public class SystemRoles : IdentityRole
    {
        public string RoleLevel { get; set; }
    }
}
