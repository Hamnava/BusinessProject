using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessProject.DataModelLayer.Entities
{
   public class RolePattern
    {
        [Key]
        public int RolePatternId { get; set; }
        public string RolePatternName { get; set; }
        public string RolePatternDesc { get; set; }
    }
}
