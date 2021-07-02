﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse.Models
{
  public class ProductsSelectedForAppointment
  {
    public int ID { get; set; }
    public int AppointmentID { get; set; }

    [ForeignKey("AppointmentID")]
    public virtual Appointments Appointments { get; set; }

    public int ProductID { get; set; }

    [ForeignKey("ProductID")]
    public Products Products { get; set; }
  }
}
