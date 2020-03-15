using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using extension = VehicleManager_UI.Extensions;

namespace VehicleManager_UI.Models
{
    internal static class ApiClient
    {
        private static readonly HttpClient _client = new HttpClient();
        private static readonly Uri _apiAbsoluteUri = new Uri("https://localhost:44334/");

        internal static class VehiclesClient
        {
            private static readonly string _apiRelativeUri = "api/vehicles";

            internal static async Task<List<VehicleAssembler>> GetAllVehicleAssemblers()
            {
                var uri = extension.UriExtensions.Combine(_apiAbsoluteUri, _apiRelativeUri);

                var response = await _client.GetAsync(uri);

                var body = response.Content.ReadAsStringAsync().Result;

                return new List<VehicleAssembler>();
            }
        }
    }
}
