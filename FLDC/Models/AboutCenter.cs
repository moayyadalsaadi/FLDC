using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Graduation_Project.Models
{
    public class AboutCenter
    {
        //this class will show الرؤية والرسالة والأهداف
          [Key]
            public int AboutCenterId { get; set; }
            [Display(Name = "المحتوى")]
            [Required(ErrorMessage = "ادخل النص")]
            public string Text { get; set; }
            //this will distinguish between الرؤية والرسالة والاهداف
            // 1 الرؤية
            // 2 الرسالة 
            // 3 الاهداف
            public int code { get; set; }        
    }
}