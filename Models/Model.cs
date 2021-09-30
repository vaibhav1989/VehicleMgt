using System;
using System.Collections.Generic;
using VehicleMgt.ViewModels;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VehicleMgt.Models
{
    public partial class Model
    {
        public Model()
        {
            Vehicles = new HashSet<Vehicles>();
        }

        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string ModelName { get; set; }
        public DateTime ProductionDate { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Vehicles> Vehicles { get; set; }
        
    }
}
