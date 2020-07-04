using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Graduation_Project.Models
{
    [Table("Applicant")]
    public class Applicant
    {
        [Key]
        public int ApplicantId { get; set; }
        [Required(ErrorMessage = "ادخل الاسم")]
        [Display(Name = "الاسم")]
        public string Name { get; set; }
        //هذا الكود يستخدم لمتابعة الطلب ويتكون من اخر 7 ارقام من الرقم القومي مع 5 ارقام عشوائي
        public string Code { get; set; }
        [Display(Name = "الجامعة")]
        public string University { get; set; }
        [Required(ErrorMessage = "ادخل اسم الكلية")]
        [Display(Name = "الكلية")]
        public string College { get; set; }
        [Required(ErrorMessage = "ادخل اسم القسم")]
        [Display(Name = "القسم")]
        public string Section { get; set; }
        [Required(ErrorMessage = "ادخل الدرجة")]
        [Display(Name = " الدرجةالعلمية")]
        public string Degree { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "الايميل")]
        public string Email { get; set; }
        [Phone]
        [Display(Name = "الهاتف")]
        public string Phone { get; set; }
        [Display(Name = "الرقم القومي")]
        public string SSN { get; set; }
        //show the state which it is confirmed, delay, or cancel
        [Display(Name = "الحالة")]
        public int? State { get; set; }
        [Display(Name = "الحالة الوظيفية")]
        public string JobState { get; set; }
        //the image of the form
        [Display(Name = "استمارة التسجيل")]
        public string Form { get; set; }
        //the imag of the payment bill
        [Display(Name = "ايصال الدفع")]
        public string Payment { get; set; }
        //the status from the college
        [Display(Name = "بيان الحالة")]
        public string Status { get; set; }
        [Column(TypeName = "date")]
        [Display(Name = "تاريخ بداية الكورس")]
        [DataType(DataType.Date)]
        public DateTime? CourseStart { get; set; }
        [Display(Name = "البرنامج التدريبي")]
        public int CourseId { get; set; }
        //Navigation property
        public virtual Course Course { get; set; }
    }
}