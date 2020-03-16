using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleManager_DAL.Models
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
