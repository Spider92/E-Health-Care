using E_Health.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Health.Models.Patient
{
    public class Problem
    {
        [Key]
        public int ProblemId { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        //public string Gender { get; set; }
        //[Required]
        //[DataType(DataType.Date)]
        //public DateTime DOB { get; set; }
        [Required]
        public string Division { get; set; }
        [Required]
        [AllowHtml]
        public string ProblemDetail { get; set; }
        //public virtual Register Register { get; set; }
    }
}