using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Graduation_Project.Models
{
    public class News
    {
        [Key]
        //this is the id
        public int NewsId { get; set; }
        [Display(Name = "محتوى الخبر")]
        [Required(ErrorMessage = "ادخل محتوى الخبر")]
        //this is the content of the news
        public string NewsContent { get; set; }
        [Display(Name ="الرابط")]
        public string Link { get; set; }
    }
}