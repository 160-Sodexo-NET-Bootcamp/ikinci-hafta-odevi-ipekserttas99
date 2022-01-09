using AutoMapper;
using Dapper;
using Data_Homework_.Context;
using Data_Homework_.Generic;
using Data_Homework_.Models;
using Data_Homework_.Operations;
using Data_Homework_.Operations.UpdateCommands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data_Homework_.Operations.CreateContainerCommand;

namespace Data_Homework_.ContainerRepo
{
    public class ContainerRepository : GenericRepository<Container> , IContainerRepository
    {
        private readonly IMapper _mapper;
        
        public ContainerRepository(TrashSystemDbContext dbContext, ILogger logger, IMapper mapper) : base(dbContext, logger)
        {
            _mapper = mapper;
        }

        public CreateContainerModel Create(CreateContainerCommand.CreateContainerModel createContainerModel)
        {
            
            CreateContainerCommand command = new CreateContainerCommand(_dbContext, _mapper);
            command.Model = createContainerModel;
            command.Handle();

            return createContainerModel;
            
        }

        public UpdateContainerCommand.UpdateContainerModel Update(int id,UpdateContainerCommand.UpdateContainerModel updateContainerModel)
        {
            UpdateContainerCommand command = new UpdateContainerCommand(_dbContext, _mapper);
            command.ContainerId = id;
            command.Model = updateContainerModel;
            command.Handle(updateContainerModel);

            return updateContainerModel;


        }
    }
}
