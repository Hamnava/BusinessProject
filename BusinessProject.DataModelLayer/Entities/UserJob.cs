using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessProject.DataModelLayer.Entities
{
   public class UserJob
    {
        [Key]
        public int UserJobId { get; set; }
        public string UserId { get; set; }
        public int JobId { get; set; }
        public DateTime StartJobDate { get; set; }
        public DateTime EndJobDate { get; set; }
        public bool IsHaveJob { get; set; }

        [ForeignKey("UserId")]
        public virtual SystemUsers User { get; set; }
        [ForeignKey("JobId")]
        public virtual SystemJobs Jobs { get; set; }
    }
}
