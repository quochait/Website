using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraniteHouse.Models
{
    public class Appointments
    {
        public int ID { get; set; }

        [Display(Name = "Sales Person")]
        public string SalesPersonID { get; set; }

        [ForeignKey("SalesPersonID")]
        public virtual ApplicationUser SalesPerson { get; set; }

        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        [Display(Name = "Appointment Time")]
        [NotMapped]
        public DateTime AppointmentTime { get; set; }

        public string CustomerName { get; set; }

        [Display(Name = "Phone Number")]
        public string CustomerPhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string CustomerEmail { get; set; }
        public bool isConfirmed { get; set; }
    }
}
