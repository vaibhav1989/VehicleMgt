using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VehicleMgt.Models
{
    public partial class ConfigurationValue
    {
        public int Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
