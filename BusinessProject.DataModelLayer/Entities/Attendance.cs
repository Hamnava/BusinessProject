using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessProject.DataModelLayer.Entities
{
   public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        public DateTime UpsentDate { get; set; }
        public byte Hours { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual SystemUsers User { get; set; }
    }
}
