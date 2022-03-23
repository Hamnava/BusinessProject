using BusinessProject.DataModelLayer.DbContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BusinessProject.Core.Interfaces;

namespace BusinessProject.Core.Services
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationContext _context;
        public RoleRepository(ApplicationContext db)
        {
            _context = db;
        }

        public string GetRoleId(string userId)
        {
            var getRoleId = _context.UserRoles.Where(rl => rl.UserId == userId).ToList();
            string stringRoleId = "";
            for (int i = 0; i < getRoleId.Count; i++)
            {
                stringRoleId += getRoleId[i].RoleId.ToString() + ",";
            }
            return stringRoleId;
        }

        public string GetRoleIdFromRolePatternId(int RolePatternId)
        {
            var getRoleId = _context.RolePatternDetails.Where(rpd => rpd.RolePatternId == RolePatternId).ToList();
            string stringRoleId = "";
            for (int i = 0; i < getRoleId.Count(); i++)
            {
                stringRoleId += getRoleId[i].RoleId.ToString() + ",";
            }
            return stringRoleId;
        }
    }
}
