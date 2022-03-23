using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessProject.DataModelLayer.Entities
{
   public class OverTime
    {
        [Key]
        public int OverTimeId { get; set; }
        public DateTime WorkDate { get; set; }
        public byte Hours { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual SystemUsers User { get; set; }
    }
}
