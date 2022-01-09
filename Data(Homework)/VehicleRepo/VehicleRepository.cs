using AutoMapper;
using Dapper;
using Data_Homework_.Context;
using Data_Homework_.Generic;
using Data_Homework_.Models;
using Data_Homework_.Operations.UpdateCommands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.VehicleRepo
{
    public class VehicleRepository : GenericRepository<Vehicle>,IVehicleRepository
    {
        private readonly IMapper _mapper;
        public VehicleRepository(TrashSystemDbContext dbContext, ILogger logger, IMapper mapper) : base(dbContext, logger)
        {
            _mapper = mapper;
        }

        public CreateVehicleCommand.CreateVehicleModel Create(CreateVehicleCommand.CreateVehicleModel createVehicleModel)
        {
            
            CreateVehicleCommand command = new CreateVehicleCommand(_dbContext, _mapper);
            command.Model = createVehicleModel;
            command.Handle();
            return createVehicleModel;
            
        }

        public async Task Delete(int id)
        {
            var sql = "DELETE FROM Vehicle WHERE Id = " + id +
                "DELETE FROM Container WHERE VehicleId = " + id;
            using (var connection = new SqlConnection("Server=IPEK; Database=trashcollectionsystem; Trusted_Connection=True;"))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public UpdateVehicleCommand.UpdateVehicleModel Update(int id, UpdateVehicleCommand.UpdateVehicleModel updateVehicleModel)
        {
            UpdateVehicleCommand command = new UpdateVehicleCommand(_dbContext, _mapper);
            command.VehicleId = id;
            command.Model = updateVehicleModel;
            command.Handle(updateVehicleModel);
            return updateVehicleModel;
        }
    }
}
