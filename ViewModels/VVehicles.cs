﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleMgt.ViewModels
{
    public class VVehicles : Models.Vehicles, IVehicles
    {
        public string ModelName { get; set; }
        public string YearCode { get ; set; }
        public string StatusCode { get ; set; }
    }
}
