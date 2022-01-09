using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly TrashSystemDbContext _dbContext;

        public CreateVehicleCommand(TrashSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var vehicle = _dbContext.Vehicle.SingleOrDefault(v => v.VehiclePlate == Model.VehiclePlate);
            vehicle = _mapper.Map<Vehicle>(Model);

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
