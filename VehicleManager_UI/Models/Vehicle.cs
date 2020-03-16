using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManager_UI.Models
{
    /// <summary>
    /// Model para Veículo.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Identificação do veículo.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da montadora.
        /// </summary>
        public string AssemblerName { get; set; }

        /// <summary>
        /// Modelo do veículo.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Placa do veículo.
        /// </summary>
        public string Plate { get; set; }
    }
}
