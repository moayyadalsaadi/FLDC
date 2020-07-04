using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Graduation_Project.Models
{
    [Table("course")]
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "ادخل الاسم")]
        [Display(Name = "البرنامج التدريبي")]
        public string Name { get; set; }
        // 1 if the course is offline
        // 2 if the course is online
        [Display(Name = "نوع الكورس")]
        public int CourseType { get; set; }
        [Display(Name = "الوصف")]
        public string Description { get; set; }
        //the number of the seats
        [Required(ErrorMessage = "ادخل عدد المقاعد")]
        [Display(Name = "عدد المقاعد")]
        public int SeatNumber { get; set; }
        //the number of seats booked
        [Display(Name = "المقاعد المحجوزة")]
        public int? SeatBooked { get; set; }
        [Column(TypeName = "date")]
        [Display(Name = "تاريخ البداية")]
        [DataType(DataType.Date)]
        public DateTime? DateStart { get; set; }
        [Column(TypeName = "date")]
        [Display(Name = "تاريخ النهاية")]
        [DataType(DataType.Date)]
        public DateTime? DateEnd { get; set; }
        [Display(Name = "الظهور")]
        public int? ShowHide { get; set; }
        [Display(Name = "ايام البرنامج")]
        public string CourseDays { get; set; }
    }
}