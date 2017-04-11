using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebProgrammingPhase2.Models
{

    //Customized data annotation validator for uploading file
    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int maxContent = 1024 * 1024; //1 MB
            string[] sAllowedExt = new string[] { ".doc", ".pdf", ".docx" };


            var file = value as HttpPostedFileBase;

            if (file == null)
                return false;
            else if (!sAllowedExt.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload Your File of type: " + string.Join(", ", sAllowedExt);
                return false;
            }
            else if (file.ContentLength > maxContent)
            {
                ErrorMessage = "Your File is too large, maximum allowed size is : " + (maxContent / 1024).ToString() + "MB";
                return false;
            }
            else
                return true;
        }
    }
    public class Applicant
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [Display(Name ="Job Title")]
        public string jobTiltile { get; set; }
        [Required]
        public string  Skills { get; set; }
       [Required]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Please browse your image")]
        //[Display(Name = "Upload Image")]
        //[NotMapped]
        //[ValidateFile]
        //public HttpPostedFileBase Attachment { get; set; }
        public string  Rating { get; set; }
        public string isTop5 { get; set; }
        public string   isHired { get; set; }
    }
}