using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using VehicleManager_UI.Models;

namespace VehicleManager_UI.Controllers
{
    /// <summary>
    /// Controller responsável pelas requisições de gerenciamento.
    /// </summary>
    public class ManagerController : Controller
    {
        /// <summary>
        /// Lista todos os veículos cadastrados.
        /// </summary>
        /// <returns></returns>
        public IActionResult ManageVehicles()
        {
            var vehicles = ApiClient.VehiclesClient.GetAllVehicles().Result;

            return View(vehicles);
        }

        /// <summary>
        /// Atualiza o veículo na base.
        /// </summary>
        /// <param name="vehicle">O veículo a ser atualizado.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateVehicle([FromBody]Vehicle vehicle)
        {
            try
            {
                var vehicleInserted = ApiClient.VehiclesClient.PutVehicle(vehicle).Result;

                if (vehicleInserted.Id > 0)
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json("Veículo atualizado com sucesso!");
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json("Não foi possível atualizar o veículo. Tente novamente mais tarde.");
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("Não foi possível atualizar o veículo. Tente novamente mais tarde.");
            }
        }

        /// <summary>
        /// Deleta o veículo cadastrado.
        /// </summary>
        /// <param name="vehicle">O veículo a ser deletado.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteVehicle([FromBody]Vehicle vehicle)
        {
            try
            {
                var vehicleDeleted = ApiClient.VehiclesClient.DeleteVehicle(vehicle).Result;

                if (vehicleDeleted)
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return View();
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json("Não foi possível descadastrar o veículo. Tente novamente mais tarde.");
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("Não foi possível descadastrar o veículo. Tente novamente mais tarde.");
            }
        }

    }
}
