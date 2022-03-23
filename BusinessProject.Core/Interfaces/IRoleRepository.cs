using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessProject.Core.Interfaces
{
   public interface IRoleRepository
    {
        string GetRoleId(string userId);
        string GetRoleIdFromRolePatternId(int RolePatternId);
    }
}
