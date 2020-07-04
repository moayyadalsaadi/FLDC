using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Graduation_Project.Models
{
    public class ContactUs
    {
        [Key]
        public int ContactUsId { get; set; }
        [Display(Name = "البريد الإلكتروني")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "التليفون")]
        public string Phone { get; set; }
        [Display(Name = "الموبايل")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
    }
}