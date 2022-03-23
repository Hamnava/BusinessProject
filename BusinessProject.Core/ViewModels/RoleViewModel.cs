using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessProject.Core.ViewModels
{
   public class RoleViewModel
    {
        [Display(Name="System Part Name")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="{0} is not entered!")]
        public string Name { get; set; }
        public string RoleLevel { get; set; }
    }
}
