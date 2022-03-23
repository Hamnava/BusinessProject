using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessProject.Core.ViewModels
{
   public class ContractViewModel
    {
        public int ContractId { get; set; }
        public string UserId { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Gross Salary Can't be empty!")]
        public int GrossSalary { get; set; }
        // 1 afs
        // 2 $
        public byte Currency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Position Field Can't be empty!")]
        public string Position { get; set; }
        // 1 Project Bassed
        // 2 Time bassed
        public byte ContractType { get; set; }
    }
}
