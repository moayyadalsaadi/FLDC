using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Graduation_Project.Models
{
    //this class will be used for الاسئلة الشائعة
    public class FAQ
    {
        [Key]
        public int FAQId { get; set; }
        [Display(Name = "السؤال")]
        public string Question { get; set; }
        [Display(Name = "الجواب")]
        public string Answer { get; set; }
    }
}