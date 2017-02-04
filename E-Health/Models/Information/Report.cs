using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Health.Models.Information
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        public int UserId { get; set; }
        public string Department { get; set; }
        [AllowHtml]
        [Required]
        public string Image { get; set; }
    }
}