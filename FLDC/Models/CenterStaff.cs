using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Graduation_Project.Models
{
    //this is الهيكل الاداري
    //1 مجلس الادارة
    //2 المدربون
    //3 المشرفون
    //4 رؤساء سابقون
    public class CenterStaff
    {
        [Key]
        public int CenterStaffId { get; set; }
        [Display(Name = "الاسم")]
        [Required(ErrorMessage = "ادخل الاسم")]
        //this is the name of the staff
        public string Name { get; set; }
        [Display(Name = "الوصف")]
        //this is a description aboutthe staff
        public string Description { get; set; }
        [Display(Name = "الصورة")]
        //this is the path to the image of the staff
        public string Path { get; set; }
        [Display(Name = "الكود")]
        //this code distinguish between staff
        public int Code { get; set; }
    }
}