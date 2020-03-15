using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleManager_DAL.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string AssemblerName { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}
