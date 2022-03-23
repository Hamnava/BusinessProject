using BusinessProject.DataModelLayer.DbContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BusinessProject.Core.Interfaces;

namespace BusinessProject.Core.Services
{
   public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public string GetContractPositionByUserId(string userId)
        {
            var ContractPosition = (from cp in _context.Contracts
                           where cp.UserId == userId
                           select cp.Position).Single();
            return ContractPosition;
        }
    }
}
