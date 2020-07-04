using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Graduation_Project.Models
{
    public class CenterAchievement
    {
        [Key]
        public int CenterAchievementId { get; set; }
        [Display(Name = "العنوان")]
        [Required(ErrorMessage = "ادخل العنوان")]
        //this is the title of the achievement
        public string Label { get; set; }
        [Display(Name = "المحتوى")]
        //this is the content of the achievement
        public string Text { get; set; }
        //this codedistingush between
        //1 انجازات المركز
        //2 قرارت الجامعة
        public int Code { get; set; }
    }
}