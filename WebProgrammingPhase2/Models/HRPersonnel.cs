using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProgrammingPhase2.Models
{
    public class HRPersonnel
    {
        public int ID { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string shortDes { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string RequiredSkills { get; set; }
        [Required(ErrorMessage ="Apply date is required")]
        [DataType(DataType.DateTime,ErrorMessage ="Enter Valid Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ApplyTill { get; set; }
        public string LongDes { get; set; }

    }
}