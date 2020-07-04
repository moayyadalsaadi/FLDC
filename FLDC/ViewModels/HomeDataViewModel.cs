using Graduation_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graduation_Project.ViewModels
{
    public class HomeDataViewModel
    {
        public List<News> news { get; set; }
        public List<CenterPhoto> CenterPhotos { get; set; }
        public List<PresidentWord> PresidentWords { get; set; }
    }
}