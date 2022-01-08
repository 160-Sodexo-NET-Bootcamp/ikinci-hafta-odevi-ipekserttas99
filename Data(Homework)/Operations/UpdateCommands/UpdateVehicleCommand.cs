using Data_Homework_.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.Operations.UpdateCommands
{
    public class UpdateVehicleCommand
    {

        public UpdateVehicleModel Model { get; set; }
        private readonly TrashSystemDbContext _dbContext;

        public UpdateVehicleCommand(TrashSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(int id, UpdateVehicleModel updateVehicleModel)
        {
            var vehicle = _dbContext.Vehicle.SingleOrDefault(v => v.Id == id);
            if(vehicle is null) { 
                throw new InvalidOperationException("Araç bulunamadı!");
             }
            vehicle.VehicleName = updateVehicleModel.VehicleName != default ? updateVehicleModel.VehicleName : vehicle.VehicleName;
            vehicle.VehiclePlate = updateVehicleModel.VehiclePlate != default ? updateVehicleModel.VehiclePlate : vehicle.VehiclePlate;

            _dbContext.SaveChanges();
        }
        public class UpdateVehicleModel
        {
            public string VehicleName { get; set; }
            public string VehiclePlate { get; set; }
        }
    }
}
