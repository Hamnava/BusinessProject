using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessProject.DataModelLayer.Entities
{
   public class Resign
    {
        [Key]
        public int ResignId { get; set; }
        public DateTime ResignDate { get; set; }
        public string Reason { get; set; }
        public string UserId_Sender { get; set; }
        public string UserId_Approved { get; set; }
        //1 approved
        //2 not approved
        public byte IsApproved { get; set; }

        [ForeignKey("UserId_Sender")]
        public virtual SystemUsers UserSender { get; set; }
        [ForeignKey("UserId_Approved")]
        public virtual SystemUsers UserApproved { get; set; }
    }
}
