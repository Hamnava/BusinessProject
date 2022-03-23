using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessProject.DataModelLayer.Entities
{
  public  class SystemJobs
    {
        [Key]
        public int JobsID { get; set; }
        public string JobsName { get; set; }
        public int JobsLevel { get; set; }
    }
}
