using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager_DAL.Models;

namespace VehicleManager_DAL.DAL
{
    /// <summary>
    /// Contexto do banco VehicleManager.
    /// </summary>
    public class VehicleManagerContext : DbContext
    {
        //Connection String do banco.
        private const string ConnectionString = "Server=localhost;Database=VehicleManager;UID=localdb;PWD=123@mudar";

        /// <summary>
        /// Objeto Entity representando a tabela.
        /// </summary>
        public DbSet<VehicleAssembler> VehicleAssembler { get; set; }

        /// <summary>
        /// Objeto Entity representando a tabela.
        /// </summary>
        public DbSet<Vehicle> Vehicle { get; set; }

        /// <summary>
        /// Método sobreescrito para utilizar SQL Server e a respectiva Connection String.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
