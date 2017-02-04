using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Health.Models.FA
{
    public class FirstAid
    {
        [Key]
        public int FirstAidID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Symptoms { get; set; }
        [AllowHtml]
        [Required]
        public string Treatment { get; set; }
    }
}