using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Health.Models.Information
{
    public class Blocked_Medicine
    {
        [Key]
        public int MedicineId { get; set; }
        [Required]
        public string Title { get; set; }

        [AllowHtml]
        [Required]
        public string Detail { get; set; }
    }
}