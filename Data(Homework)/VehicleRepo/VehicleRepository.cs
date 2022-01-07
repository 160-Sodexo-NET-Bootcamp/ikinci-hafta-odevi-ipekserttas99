using Dapper;
using Data_Homework_.Context;
using Data_Homework_.Generic;
using Data_Homework_.Models;
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
        
        public VehicleRepository(TrashSystemDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
            
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

    }
}
