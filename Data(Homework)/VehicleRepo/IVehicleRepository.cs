using Data_Homework_.Generic;
using Data_Homework_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data_Homework_.Models.CreateVehicleCommand;
using static Data_Homework_.Operations.UpdateCommands.UpdateVehicleCommand;

namespace Data_Homework_.VehicleRepo
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        CreateVehicleModel Create(CreateVehicleModel createVehicleModel);
        UpdateVehicleModel Update(int id, UpdateVehicleModel updateVehicleModel);
    }
}
