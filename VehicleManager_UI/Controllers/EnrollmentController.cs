using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VehicleManager_UI.Models;

namespace VehicleManager_UI.Controllers
{
    /// <summary>
    /// Controller responsável pelas requisições de cadastro.
    /// </summary>
    public class EnrollmentController : Controller
    {
        /// <summary>
        /// Tela de cadastro trazendo todas as montadoras.
        /// </summary>
        /// <returns></returns>
        public IActionResult VehicleEnrollment()
        {
            var assemblers = ApiClient.VehiclesClient.GetAllVehicleAssemblers().Result;

            ViewBag.VehicleAssemblers = JsonConvert.SerializeObject(assemblers);

            return View();
        }

        /// <summary>
        /// Cadastro de veículo.
        /// </summary>
        /// <param name="vehicle">O veículo a ser cadastrado.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EnrollVehicle([FromBody]Vehicle vehicle)
        {
            try
            {
                var vehicleInserted = ApiClient.VehiclesClient.PostVehicle(vehicle).Result;

                if (vehicleInserted.Id > 0)
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json("Veículo cadastrado com sucesso!");
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json("Não foi possível cadastrar o veículo. Tente novamente mais tarde.");
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("Não foi possível cadastrar o veículo. Tente novamente mais tarde.");
            }
        }

    }
}
