using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VehicleMgt.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Model = new HashSet<Model>();
        }

        public int Id { get; set; }
        public string ManufacturerName { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Model> Model { get; set; }
    }
}
