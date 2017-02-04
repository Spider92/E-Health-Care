using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Health.Models.Doctor
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }
    }
}