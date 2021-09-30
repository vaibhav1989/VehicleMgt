using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleMgt.ViewModels
{
    public interface IModel
    {
        //public int Id { get; set; }
        //public int ManufacturerId { get; set; }
        //public string ModelName { get; set; }
        //public DateTime ProductionDate { get; set; }

        public string ManufacturerName { get; set; }
    }
}
