using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleManager_DAL.DAL;
using VehicleManager_DAL.Models;

namespace VehicleManager_BLL
{
    /// <summary>
    /// Classe responsável pela regra de negócio de gerenciamento de veículos.
    /// </summary>
    public class ManagerVehicles
    {
        /// <summary>
        /// Efetua a lógica e requisita a DAL recuperando todos os veículos.
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> GetAllVehicles()
        {
            var vehicles = new List<Vehicle>();

            using (var context = new VehicleManagerContext())
            {
                vehicles = context.Vehicle.ToList();
            }

            return vehicles;
        }

        /// <summary>
        /// Efetua a lógica e requisita a DAL atualizando o veículo.
        /// </summary>
        /// <param name="vehicle">Veículo a ser atualizado.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Efetua a lógica e requisita a DAL deletando o veículo.
        /// </summary>
        /// <param name="vehicle">Veículo a ser deletado.</param>
        /// <returns></returns>
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
