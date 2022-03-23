using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessProject.Core.ViewModels
{
   public class PaymentViewModel
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public float MainSalary { get; set; }
        public float PayedAmount { get; set; }
        public float bonus { get; set; }
        public float Tax { get; set; }
        public float TotalPayed { get; set; }
        public float RemianSalary { get; set; }

        public string UserID { get; set; }
        public int JobID { get; set; }
    }
}
