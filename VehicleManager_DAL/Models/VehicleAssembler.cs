using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleManager_DAL.Models
{
    /// <summary>
    /// Model para a Montadora do Veículo.
    /// </summary>
    public class VehicleAssembler
    {
        /// <summary>
        /// Identificação no banco da montadora.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Nome da montadora.
        /// </summary>
        public string Name { get; set; }
    }

}
