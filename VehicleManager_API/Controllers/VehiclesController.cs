using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleManager_BLL;
using VehicleManager_DAL.Models;

namespace VehicleManager_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {

        [HttpGet("all/vehicles")]
        public ActionResult<List<Vehicle>> GetAll()
        {
            var listVehicles = new ManagerVehicles().GetAllVehicles();

            return listVehicles;
        }

        [HttpGet("all/vehicleassemblers")]
        public ActionResult<List<VehicleAssembler>> GetAllVehicleAssemblers()
        {
            var assemblers = new VehicleEnrollment().GetAllAssemblers();

            return assemblers;
        }

        [HttpPost("insert/vehicle")]
        public ActionResult<Vehicle> InsertVehicle([FromBody]Vehicle vehicle)
        {
            var vehicleInserted = new VehicleEnrollment().InsertVehicle(vehicle);

            return vehicleInserted;
        }

        [HttpPut("update/vehicle")]
        public ActionResult<Vehicle> Put([FromBody]Vehicle vehicle)
        {
            var vehicleUpdated = new ManagerVehicles().UpdateVehicle(vehicle);

            return vehicleUpdated;
        }

        [HttpPost("delete/vehicle")]
        public ActionResult<bool> Delete([FromBody]Vehicle vehicle)
        {
            var vehicleDeleted = new ManagerVehicles().DeleteVehicle(vehicle);

            return vehicleDeleted;
        }
    }
}
