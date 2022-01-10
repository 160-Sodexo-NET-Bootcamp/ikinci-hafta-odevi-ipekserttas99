using Data_Homework_.Generic;
using Data_Homework_.Models;
using Data_Homework_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.VehicleRepo
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        Task Create(CreateVehicleViewModel createVehicleModel);
        Task Update(int id, UpdateVehicleViewModel updateVehicleModel);
    }
}
