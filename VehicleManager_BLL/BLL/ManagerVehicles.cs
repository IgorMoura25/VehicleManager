using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleManager_DAL.DAL;
using VehicleManager_DAL.Models;

namespace VehicleManager_BLL
{
    public class ManagerVehicles
    {
        public List<Vehicle> GetAllVehicles()
        {
            var vehicles = new List<Vehicle>();

            using (var context = new VehicleManagerContext())
            {
                vehicles = context.Vehicle.ToList();
            }

            return vehicles;
        }

        public Vehicle UpdateVehicle(Vehicle vehicle)
        {
            vehicle.Plate = vehicle.Plate.Replace("-", "");

            using (var context = new VehicleManagerContext())
            {
                context.Update(vehicle);
                context.SaveChanges();
            }

            return vehicle;
        }

        public bool DeleteVehicle(Vehicle vehicle)
        {

            using (var context = new VehicleManagerContext())
            {
                context.Remove(vehicle);
                context.SaveChanges();
            }

            return true;
        }
    }
}
