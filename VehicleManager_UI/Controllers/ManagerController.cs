using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VehicleManager_UI.Models;

namespace VehicleManager_UI.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult ManageVehicles()
        {
            var vehicles = ApiClient.VehiclesClient.GetAllVehicles().Result;

            return View(vehicles);
        }

        [HttpPost]
        public IActionResult UpdateVehicle([FromBody]Vehicle vehicle)
        {
            var vehicleInserted = ApiClient.VehiclesClient.PutVehicle(vehicle).Result;

            if (vehicleInserted.Id > 0)
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("Veículo atualizado com sucesso!");
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("Não foi possível atualizar o veículo. Tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public IActionResult DeleteVehicle([FromBody]Vehicle vehicle)
        {
            var vehicleDeleted = ApiClient.VehiclesClient.DeleteVehicle(vehicle).Result;

            if (vehicleDeleted)
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
                return View();
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("Não foi possível descadastrar o veículo. Tente novamente mais tarde.");
            }
        }

    }
}
