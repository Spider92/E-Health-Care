using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Health.Models.Doctor
{
    public class Doctors
    {
        [Key]
        public int DoctorId { get; set; }
        [Required][DisplayName("Name")]
        public string DoctorName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [MinLength(length: 8, ErrorMessage = "Password must be at least 8 characters long!")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match!!")]
        public string ConfirmPassword { get; set; }
        [Required]
        [DisplayName("Gender")]
        public string Gender { get; set; }
        [Required]
        [DisplayName("Department")]
        public string Division { get; set; }
        [Required(ErrorMessage = "Department can not be empty!")]
        [DisplayName("Working place")]
        public string PresentPosition { get; set; }
        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNo { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Photo")]
        public string Photo { get; set; }
    }
}