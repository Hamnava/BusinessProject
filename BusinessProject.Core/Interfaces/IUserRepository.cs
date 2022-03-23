using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessProject.Core.Interfaces
{
   public interface IUserRepository
    {
        string GetContractPositionByUserId(string userId);
    }
}
