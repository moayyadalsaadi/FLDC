using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Graduation_Project.Models
{
    //this is the كلمة رئيس الجامعة والنائب والمدير
    //1 كلمة رئيس الجامعة
    //2 كلمة نائب الرئيس
    //3 كلمة مدير المركز
    public class PresidentWord
    {
        [Key]
        public int PresidentWordId { get; set; }
        [Display(Name = "الاسم")]
        [Required(ErrorMessage = "ادخل الاسم")]
        //this is the name of the manager
        public string Name { get; set; }
        [Display(Name = "الوصف")]
        //this is a description about the manager
        public string Description { get; set; }
        [Display(Name = "المحتوى")]
        //this is the content of the word
        public string Text { get; set; }
        [Display(Name = "الصورة")]
        //this is the path of image
        public string Path { get; set; }
        //this code is used to distingush between 
        //1 كلمة رئيس الجامعة
        //2 كلمة نائب الرئيس
        //3 كلمة مدير المركز
        public int Code { get; set; }
    }
}