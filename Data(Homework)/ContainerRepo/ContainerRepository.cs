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

namespace Data_Homework_.ContainerRepo
{
    public class ContainerRepository : GenericRepository<Container> , IContainerRepository 
    {
        
        public ContainerRepository(TrashSystemDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
            
        }
    }
}
