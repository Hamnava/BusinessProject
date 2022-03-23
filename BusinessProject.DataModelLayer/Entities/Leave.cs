using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessProject.DataModelLayer.Entities
{
   public class Leave
    {
        [Key]
        public int LeaveID { get; set; }
        //1 ساعتی
        //2 استحقاقی
        //3 استعلاجی
        //4 بدون حقوق
        public byte LeaveType { get; set; }

        public DateTime? FromDate_Day { get; set; }
        public DateTime? ToDate_Day { get; set; }
        public DateTime? FromTime_Saati { get; set; }
        public DateTime? ToTime_Saati { get; set; }
        public string Description { get; set; }
        //تاریخ ثبت درخواست
        public DateTime LeaveRequestDate { get; set; }
        public string UserID_Request { get; set; }
        public string UserID_Confirm { get; set; }
        //1 در حال بررسی
        //2 پذیرفته شده
        //3 رد شده
        public byte LeaveAccept { get; set; }

        //
        [ForeignKey("UserID_Request")]
        public virtual SystemUsers User_Request { get; set; }
        [ForeignKey("UserID_Confirm")]
        public virtual SystemUsers User_Confirm { get; set; }

    }
}
