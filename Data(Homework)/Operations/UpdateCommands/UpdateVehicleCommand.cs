using AutoMapper;
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
        private readonly IMapper _mapper;
        public int VehicleId { get; set; }
        public UpdateVehicleModel Model { get; set; }
        private readonly TrashSystemDbContext _dbContext;

        public UpdateVehicleCommand(TrashSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(UpdateVehicleModel updateVehicleModel)
        {
            var vehicle = _dbContext.Vehicle.Where(vehicle => vehicle.Id == VehicleId).SingleOrDefault();
            _mapper.Map(Model, vehicle);
            _dbContext.SaveChanges();
        }
        public class UpdateVehicleModel
        {
            public string VehicleName { get; set; }
            public string VehiclePlate { get; set; }
        }
    }
}
