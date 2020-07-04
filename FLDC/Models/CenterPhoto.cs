using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Graduation_Project.Models
{
    public class CenterPhoto
    {
        [Key]
        public int CenterPhotosId { get; set; }
        [Display(Name = "الوصف")]
        public string Description { get; set; }
        //this is the path of the image
        [Display(Name = "الصورة")]
        public string Path { get; set; }
    }
}