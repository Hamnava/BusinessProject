using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessProject.Core.ViewModels
{
    public class UserViewModel
    {
        public string Id  { get; set; }
        [Display(Name ="First Name")]
        [StringLength(maximumLength:100, MinimumLength =3, ErrorMessage = "{0} Should contains at least 3 and at most 100 character ")]
        [Required(ErrorMessage ="{0} can't be empty!")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage ="Please don't use Illigle characters for {0}")]
        public string FirstName { get; set; }
        [Display(Name = "Family")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "{0} Should contains at least 3 and at most 200 character ")]
        [Required(ErrorMessage = "{0} can't be empty!")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "Please don't use Illigle characters for {0}")]

        public string Family { get; set; }

        [Display(Name = "Address")]
        [StringLength(maximumLength: 250, MinimumLength = 3, ErrorMessage = "{0} Should contains at least 3 and at most 100 character ")]
        [Required(ErrorMessage = "{0} can't be empty!")]
        public string Address { get; set; }
        [Display(Name = "Image")]
        public string UserImg { get; set; }
        [Display(Name = "Signature")]
        public string SignatureImg { get; set; }
        [Display(Name = "Birthday Date")]
        [Required(ErrorMessage = "Please enter BirthDay Date")]
        public DateTime Birthday { get; set; }
        [Display(Name = "Gender")]
        public byte Gender { get; set; }

        [Display(Name = "ID Card")]
        [RegularExpression("^[0-9]*$",ErrorMessage ="{0} has not the correct format")]
        [Required(ErrorMessage = "Please enter {0}")]
        public int MilliCode { get; set; }

        [Display(Name = "Personal Code")]
        [MinLength(5, ErrorMessage = "{0} should contains at least 5 characters!")]
        [Required(ErrorMessage = "Please enter {0}")]
        public string PersonalCode { get; set; }
        [Display(Name = "Salary")]
        
        [Required(ErrorMessage = "Please enter {0}")]
        public int Salary { get; set; }
        [Display(Name = "Phone")]
        [MinLength(10, ErrorMessage = "{0} should contains at least 10 characters!")]
        [MaxLength(10, ErrorMessage = "{0} should contains at most 10 characters!")]
        [Required(ErrorMessage = "Please enter {0}")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email")]
        [MinLength(10, ErrorMessage = "{0} should contains at least 10 characters!")]
        [MaxLength(100, ErrorMessage = "{0} should contains at most 100 characters!")]
        [EmailAddress(ErrorMessage ="Email is not in correct format")]
        [Required(ErrorMessage = "Please enter {0}")]
        public string Email { get; set; }
        [Display(Name = "User Name")]
        [MinLength(5, ErrorMessage = "{0} should contains at least 5 characters!")]
        [MaxLength(100, ErrorMessage = "{0} should contains at most 100 characters!")]
        [Required(ErrorMessage = "Please enter {0}")]
        public string UserName { get; set; }
        public byte IsAdmin { get; set; }
    }

    public class UserFullNameWithJobName
    {
        public string UserId { get; set; }
        public string UserFullNameWithJob { get; set; }
    }

    public class ChangePasswordByAdminViewModel
    {

        [Display(Name = "New Password")]
        public string NewPassword { get; set; }


        [Display(Name = "Confirm Password")]
        public string ConfirmNewPassword { get; set; }

        public string userId { get; set; }
    }

    public class LoginViewModel
    {
        [Display(Name ="User Name :")]
        [Required(ErrorMessage ="Enter the User Name!")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "Please don't use Illigle characters for {0}")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Enter the Password !!")]
        
        public string Password { get; set; }
    }
}
