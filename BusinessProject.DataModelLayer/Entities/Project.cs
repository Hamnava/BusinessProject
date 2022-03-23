using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessProject.DataModelLayer.Entities
{
   public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public int ProjectCode { get; set; }
        public int ProjectCost { get; set; }
        public string ProjectName { get; set; }
        public string DoonarName { get; set; }
        public byte ProjectType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
    }
}
