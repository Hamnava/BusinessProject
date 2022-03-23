using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessProject.DataModelLayer.Entities
{
  public  class Letter
    {
        [Key]
        public int LetterId { get; set; }
        public string LetterContent { get; set; }
        public string LetterSubject { get; set; }
        public byte ImmediatellyStatus { get; set; }
        public byte Classification { get; set; }
        public bool AttachmentStatus { get; set; }
        public bool replayDateStatus { get; set; }
        public string UserId { get; set; }
        public DateTime? ReplyDate { get; set; }
        public DateTime LetterCreatDate { get; set; }
        public string AttachmentFile { get; set; }

        [ForeignKey("UserId")]
        public virtual SystemUsers Users { get; set; }
    }
}
