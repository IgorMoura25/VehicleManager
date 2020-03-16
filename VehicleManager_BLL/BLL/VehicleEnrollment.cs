using System;
using System.Collections.Generic;
using System.Linq;
using VehicleManager_DAL.DAL;
using VehicleManager_DAL.Models;

namespace VehicleManager_BLL
{
    /// <summary>
    /// Classe responsável pela regra de negócio de cadastro de veículos.
    /// </summary>
    public class VehicleEnrollment
    {
        /// <summary>
        /// Efetua a lógica e requisita a DAL recuperando todas as montadoras.
        /// </summary>
        /// <returns></returns>
        public List<VehicleAssembler> GetAllAssemblers()
        {
            var assemblers = new List<VehicleAssembler>();

            using (var context = new VehicleManagerContext())
            {
                assemblers = context.VehicleAssembler.ToList();
            }

            return assemblers;
        }

        /// <summary>
        /// Efetua a lógica e requisita a DAL inserindo o veículo.
        /// </summary>
        /// <param name="vehicle">O veículo a ser inserido.</param>
        /// <returns></returns>
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
