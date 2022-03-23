using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessProject.DataModelLayer.Entities
{
    public class AdminstrativeForm
    {
        [Key]
        public int AdminstrativeFormId { get; set; }
        public bool AdminstrativeFormType { get; set; }
        public string AdminstrativeFormTitle { get; set; }
        public string AdminstrativeFormContent { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual SystemUsers User { get; set; }

    }
}
