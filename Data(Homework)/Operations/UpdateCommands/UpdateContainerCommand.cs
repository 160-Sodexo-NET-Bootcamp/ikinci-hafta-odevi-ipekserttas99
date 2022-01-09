using AutoMapper;
using Data_Homework_.Context;
using Data_Homework_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.Operations.UpdateCommands
{
    public class UpdateContainerCommand
    {
        public UpdateContainerModel Model { get; set; }
        private readonly TrashSystemDbContext _dbContext;
        private readonly IMapper _mapper;
        public int ContainerId { get; set; }
        public UpdateContainerCommand(TrashSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(UpdateContainerModel updateContainerModel)
        {
            var container = _dbContext.Container.Where(container => container.Id == ContainerId).SingleOrDefault();
            _mapper.Map(Model, container);
            _dbContext.SaveChanges();
        }




        public class UpdateContainerModel
        {
            public string ContainerName { get; set; }
            [Column(TypeName = "decimal(10, 6)")]
            public decimal Latitude { get; set; }
            [Column(TypeName = "decimal(10, 6)")]
            public decimal Longitude { get; set; }
        }
    }
}
