using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessProject.Core.ViewModels
{
   
   public class JobsChartViewModel
    {
        public int JobsID { get; set; }
        public string JobsName { get; set; }
        public int JobsLevel { get; set; }
        public string FirstName { get; set; }
        public string Family { get; set; }
    }
    public class JobsChartWithUserInfoViewModel
    {
        public int JobsID { get; set; }
        public string JobsName { get; set; }
        public int JobsLevel { get; set; }
        public string FirstName { get; set; }
        public string Family { get; set; }
    }
}
