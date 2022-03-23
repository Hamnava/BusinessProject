using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessProject.DataModelLayer.Entities
{
   public class SystemUsers : IdentityUser
    {
        public string FirstName { get; set; }
        public string Family { get; set; }
        public string Address { get; set; }
        public string UserImg { get; set; }
        public string SignatureImg { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime RegisterDate { get; set; }
        public byte Gender { get; set; }
        public byte IsActive { get; set; }
        public int MilliCode { get; set; }
        public string PersonalCode { get; set; }
        public int Salary { get; set; }
        public byte IsAdmin { get; set; }
    }
}
