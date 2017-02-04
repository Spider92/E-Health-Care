using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Health.Models.Information
{
    public class Health_Banner
    {
        [Key]
        public int BannerId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Image { get; set; }
    }
}