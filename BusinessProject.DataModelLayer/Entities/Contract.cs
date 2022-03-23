using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessProject.DataModelLayer.Entities
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }
        public string UserId { get; set; }
        public int GrossSalary { get; set; }
        // 1 afs
        // 2 $
        public byte Currency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Position { get; set; }
        // 1 Project Bassed
        // 2 Time bassed
        public byte ContractType { get; set; }

        [ForeignKey("UserId")]
        public virtual SystemUsers User { get; set; }

    }
}
