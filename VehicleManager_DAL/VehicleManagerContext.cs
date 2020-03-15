using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager_DAL.Model;

namespace VehicleManager_DAL.DAL
{
    public class VehicleManagerContext : DbContext
    {
        private const string ConnectionString = "Server=localhost;Database=VehicleManager;UID=localdb;PWD=123@mudar";

        public DbSet<VehicleAssembler> VehicleAssembler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
