using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessProject.Core.ViewModels
{
   public class AdminstrativeDefaultFormViewModel
    {
        public int AdminstrativeFormId { get; set; }
        public bool AdminstrativeFormType { get; set; }
        [Display(Name ="Title")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Title should not be empty!")]
        public string AdminstrativeFormTitle { get; set; }
        [Display(Name = "Content")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Content should not be empty!")]
        public string AdminstrativeFormContent { get; set; }
        public string UserId { get; set; }
    }
}
