using System;
using VehicleManager_DAL.DAL;
using VehicleManager_DAL.Model;

namespace VehicleManager_BLL
{
    public class VehicleEnrollment
    {
        public void GetAllVehicleAssemblers()
        {
            var assembler = new VehicleAssembler() { Name = "Chevrolet" };

            using (var context = new VehicleManagerContext())
            {
                context.Add(assembler);
                context.SaveChanges();
            }
        }
    }
}
