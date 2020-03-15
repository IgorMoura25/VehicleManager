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
            var assemblers = ApiClient.VehiclesClient.GetAllVehicleAssemblers().Result;

            ViewBag.VehicleAssemblers = JsonConvert.SerializeObject(assemblers);

            return View();
        }

        [HttpPost]
        public IActionResult EnrollVehicle([FromBody]Vehicle vehicle)
        {
            var vehicleInserted = ApiClient.VehiclesClient.PostVehicle(vehicle).Result;

            if (vehicleInserted.Id > 0)
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("Veículo cadastrado com sucesso!");
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json("Não foi possível cadastrar o veículo. Tente novamente mais tarde.");
            }
        }

        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

    }
}
