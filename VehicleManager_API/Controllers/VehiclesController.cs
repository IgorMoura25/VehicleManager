using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleManager_BLL;
using VehicleManager_DAL.Models;

namespace VehicleManager_API.Controllers
{
    /// <summary>
    /// Controller responsável pelas requisições de Veículos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        #region ...CRUD Veículos...

        /// <summary>
        /// GET: Recupera todos os veículos do banco.
        /// </summary>
        /// <returns>Uma lista de veículos.</returns>
        [HttpGet("all/vehicles")]
        public ActionResult<List<Vehicle>> GetAll()
        {
            var listVehicles = new ManagerVehicles().GetAllVehicles();

            return listVehicles;
        }

        /// <summary>
        /// POST: Insere um veículo no banco.
        /// </summary>
        /// <param name="vehicle">O veículo a ser inserido.</param>
        /// <returns>O veículo inserido.</returns>
        [HttpPost("insert/vehicle")]
        public ActionResult<Vehicle> InsertVehicle([FromBody]Vehicle vehicle)
        {
            var vehicleInserted = new VehicleEnrollment().InsertVehicle(vehicle);

            return vehicleInserted;
        }

        /// <summary>
        /// POST: Atualiza um veículo no banco.
        /// </summary>
        /// <param name="vehicle">O veículo a ser atualizado.</param>
        /// <returns>O veículo atualizado.</returns>
        [HttpPut("update/vehicle")]
        public ActionResult<Vehicle> Put([FromBody]Vehicle vehicle)
        {
            var vehicleUpdated = new ManagerVehicles().UpdateVehicle(vehicle);

            return vehicleUpdated;
        }

        /// <summary>
        /// POST: Deleta um veículo no banco.
        /// </summary>
        /// <param name="vehicle">O veículo a ser deletado.</param>
        /// <returns>Se foi deletado com sucesso.</returns>
        [HttpPost("delete/vehicle")]
        public ActionResult<bool> Delete([FromBody]Vehicle vehicle)
        {
            var vehicleDeleted = new ManagerVehicles().DeleteVehicle(vehicle);

            return vehicleDeleted;
        }

        #endregion

        #region ...CRUD Montadora...

        /// <summary>
        /// GET: Recupera todas as montadoras de veículos do banco.
        /// </summary>
        /// <returns>Uma lista de montadoras de veículos.</returns>
        [HttpGet("all/vehicleassemblers")]
        public ActionResult<List<VehicleAssembler>> GetAllVehicleAssemblers()
        {
            var assemblers = new VehicleEnrollment().GetAllAssemblers();

            return assemblers;
        }

        #endregion
    }
}
