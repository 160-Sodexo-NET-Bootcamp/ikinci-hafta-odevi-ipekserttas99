using Data_Homework_.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.Models
{
    public class CreateVehicleCommand
    {
        public CreateVehicleModel Model { get; set; }

        private readonly TrashSystemDbContext _dbContext;

        public CreateVehicleCommand(TrashSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var vehicle = _dbContext.Vehicle.SingleOrDefault(v => v.VehiclePlate == Model.VehiclePlate);
            if (vehicle is not null)
                throw new InvalidOperationException("Araç zaten mevcut");

            vehicle = new Vehicle();
            vehicle.VehicleName = Model.VehicleName;
            vehicle.VehiclePlate = Model.VehiclePlate;

            _dbContext.Vehicle.Add(vehicle);
            _dbContext.SaveChanges();
        }
        public class CreateVehicleModel
        {
            public string VehicleName { get; set; }
            public string VehiclePlate { get; set; }
        }
    }
}
