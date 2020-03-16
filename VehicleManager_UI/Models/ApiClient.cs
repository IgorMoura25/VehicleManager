using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using extension = VehicleManager_UI.Extensions;

namespace VehicleManager_UI.Models
{
    /// <summary>
    /// Classe responsável pelas requisições à camada API.
    /// </summary>
    internal static class ApiClient
    {

        #region Propriedades

        /// <summary>
        /// Única instância de HttpClient.
        /// </summary>
        private static readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// URI absoluta da API.
        /// </summary>
        private static readonly Uri _apiAbsoluteUri = new Uri("https://localhost:44334/");

        #endregion


        #region Controllers API - Vehicles

        /// <summary>
        /// Classe responsável pelas requisições ao controller Vehicles da API.
        /// </summary>
        internal static class VehiclesClient
        {

            #region ...Caminho relativo...

            private static readonly string _apiRelativeUri = "api/vehicles";

            #endregion


            #region ...CRUD Montadora...

            internal static async Task<List<VehicleAssembler>> GetAllVehicleAssemblers()
            {
                var uri = extension.UriExtensions.Combine(_apiAbsoluteUri, _apiRelativeUri, "all/vehicleassemblers");

                var httpResponse = await _client.GetAsync(uri);

                var result = httpResponse.Content.ReadAsStringAsync().Result;

                var assemblerList = JsonConvert.DeserializeObject<List<VehicleAssembler>>(result);

                return assemblerList;
            }

            #endregion

            #region ...CRUD Veículo...

            //GET
            internal static async Task<List<Vehicle>> GetAllVehicles()
            {
                var uri = extension.UriExtensions.Combine(_apiAbsoluteUri, _apiRelativeUri, "all/vehicles");

                var httpResponse = await _client.GetAsync(uri);

                var result = httpResponse.Content.ReadAsStringAsync().Result;

                var vehicleList = JsonConvert.DeserializeObject<List<Vehicle>>(result);

                return vehicleList;
            }

            //POST
            internal static async Task<Vehicle> PostVehicle(Vehicle vehicle)
            {
                var uri = extension.UriExtensions.Combine(_apiAbsoluteUri, _apiRelativeUri, "insert/vehicle");
                var content = new StringContent(JsonConvert.SerializeObject(vehicle), Encoding.UTF8, "application/json");

                var httpResponse = await _client.PostAsync(uri, content);

                var result = httpResponse.Content.ReadAsStringAsync().Result;

                var vehicleInserted = JsonConvert.DeserializeObject<Vehicle>(result);

                return vehicleInserted;
            }

            //PUT
            internal static async Task<Vehicle> PutVehicle(Vehicle vehicle)
            {
                var uri = extension.UriExtensions.Combine(_apiAbsoluteUri, _apiRelativeUri, "update/vehicle");
                var content = new StringContent(JsonConvert.SerializeObject(vehicle), Encoding.UTF8, "application/json");

                var httpResponse = await _client.PutAsync(uri, content);

                var result = httpResponse.Content.ReadAsStringAsync().Result;

                var vehicleUpdated = JsonConvert.DeserializeObject<Vehicle>(result);

                return vehicleUpdated;
            }

            //DELETE
            internal static async Task<bool> DeleteVehicle(Vehicle vehicle)
            {
                var uri = extension.UriExtensions.Combine(_apiAbsoluteUri, _apiRelativeUri, "delete/vehicle");
                var content = new StringContent(JsonConvert.SerializeObject(vehicle), Encoding.UTF8, "application/json");

                var httpResponse = await _client.PostAsync(uri, content);

                var result = httpResponse.Content.ReadAsStringAsync().Result;

                var vehicleUpdated = JsonConvert.DeserializeObject<bool>(result);

                return vehicleUpdated;
            }

            #endregion

        }

        #endregion

    }
}
