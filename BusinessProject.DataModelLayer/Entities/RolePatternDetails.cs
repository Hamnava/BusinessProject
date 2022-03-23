using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessProject.DataModelLayer.Entities
{
   public class RolePatternDetails
    {
        [Key]
        public int RolePatternDetailsId { get; set; }
        public int RolePatternId { get; set; }
        public string RoleId { get; set; }

        [ForeignKey("RolePatternId")]
        public virtual RolePattern RolePattern { get; set; }
        [ForeignKey("RoleId")]
        public virtual SystemRoles Roles { get; set; }
    }
}
