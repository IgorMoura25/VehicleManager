using System;
using System.Collections.Generic;
using System.Linq;
using VehicleManager_DAL.DAL;
using VehicleManager_DAL.Models;

namespace VehicleManager_BLL
{
    public class VehicleEnrollment
    {
        public List<VehicleAssembler> GetAllAssemblers()
        {
            var assemblers = new List<VehicleAssembler>();

            using (var context = new VehicleManagerContext())
            {
                assemblers = context.VehicleAssembler.ToList();
            }

            return assemblers;
        }

        public Vehicle InsertVehicle(Vehicle vehicle)
        {
            vehicle.Plate = vehicle.Plate.Replace("-", "");

            using (var context = new VehicleManagerContext())
            {
                context.Add(vehicle);
                context.SaveChanges();
            }

            return vehicle;
        }
    }
}
