using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessProject.Core.ViewModels
{
    public class LettersViewModel
    {
        public int LetterId { get; set; }
        [Display(Name ="Letter Content")]
        [Required (AllowEmptyStrings =false, ErrorMessage ="{0} is not entered, please enter it")]
        [MinLength (10, ErrorMessage = "{0} can not be less than 10 chracters")]
        [MaxLength (500, ErrorMessage = "{0} can not be more than 500 chracters")]
        public string LetterContent { get; set; }
        [Display(Name = "Letter Subject")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is not entered, please enter it")]
        [MinLength(5, ErrorMessage = "{0} can not be less than 5 chracters")]
        [MaxLength(50, ErrorMessage = "{0} can not be more than 50 chracters")]
        public string LetterSubject { get; set; }
        [Display(Name = "Immediately status")]
        public byte ImmediatellyStatus { get; set; }
        [Display(Name = "Classification")]
        public byte Classification { get; set; }

        [Display(Name = "Attachment Status")]
        public byte AttachmentStatus { get; set; }
        [Display(Name = "Reply-Date Status")]
        public byte replayDateStatus { get; set; }
      
        public string UserId { get; set; }
        [Display(Name = "Reply Date")]
        
        public DateTime ReplyDate { get; set; }
        public DateTime LetterCreatDate { get; set; }
        public string AttachmentFile { get; set; }
    }

    public class LettersListViewModel
    {
        public int LetterId { get; set; }
        public string LetterContent { get; set; }
        public string LetterSubject { get; set; }
        // 1 Normal
        // 2 Orgent
        // 3 Momentary
        public byte ImmediatellyStatus { get; set; }
        public string ImmediatellyStatusText { get; set; }

        // 1 Normal
        // 2 private
        // 3 Secret
        public byte Classification { get; set; }
        public string ClassificationText { get; set; }
        // 1(true) Has
        // 0(False) Doesn't have
        public bool AttachmentStatus { get; set; }
        public string AttachmentStatusText { get; set; }

        // 1(true) Has
        // 0(False) Doesn't have
        public bool replayDateStatus { get; set; }
        public string replayDateStatusText { get; set; }
        public string UserId { get; set; }
        public DateTime? ReplyDate { get; set; }
        public DateTime LetterCreatDate { get; set; }
        public string AttachmentFile { get; set; }

    }
}
