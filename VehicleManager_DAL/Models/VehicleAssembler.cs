using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleManager_DAL.Models
{
    public class VehicleAssembler
    {
        public int Id { get; protected set; }
        public string Name { get; set; }
    }
}
