using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VehicleMgt.Models
{
    public partial class Vehicles
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int Year { get; set; }
        public string Colour { get; set; }
        public int Status { get; set; }

        public virtual Model Model { get; set; }
    }
}
