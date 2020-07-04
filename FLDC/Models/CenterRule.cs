using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Graduation_Project.Models
{
    //this will control 
    //1 قواعد المركز
    //2 لوائح المركز
    //3 انشطة المركز
    public class CenterRule
    {
        [Key]
        public int CenterRuleId { get; set; }
        [Display(Name = "النص")]
        [Required(ErrorMessage = "ادخل النص")]
        public string Text { get; set; }
        [Display(Name = "الكود")]
        public int Code { get; set; }
    }
}