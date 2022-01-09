using AutoMapper;
using Data_Homework_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data_Homework_.Models.CreateVehicleCommand;
using static Data_Homework_.Operations.CreateContainerCommand;
using static Data_Homework_.Operations.UpdateCommands.UpdateContainerCommand;
using static Data_Homework_.Operations.UpdateCommands.UpdateVehicleCommand;

namespace Data_Homework_.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateContainerModel, Container>();
            CreateMap<Container, CreateContainerModel>();
            CreateMap<CreateVehicleModel, Vehicle>();
            CreateMap<Vehicle, CreateVehicleModel>();
            CreateMap<UpdateContainerModel, Container>();
            CreateMap<Container, UpdateContainerModel>();
            CreateMap<UpdateVehicleModel, Vehicle>();
            CreateMap<Vehicle, UpdateVehicleModel>();
        }
    }
}
