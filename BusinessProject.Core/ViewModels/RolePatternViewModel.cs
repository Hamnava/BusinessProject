using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessProject.Core.ViewModels
{
    public class RolePatternViewModel
    {
        public int RolePatternId { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Positon name should not be empty!")]
        public string RolePatternName { get; set; }
        public string RolePatternDesc { get; set; }
    }
}
