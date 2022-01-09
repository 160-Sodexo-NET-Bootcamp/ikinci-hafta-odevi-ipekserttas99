using AutoMapper;
using Data_Homework_.Context;
using Data_Homework_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.Operations
{
    public class CreateContainerCommand
    {
        public CreateContainerModel Model { get; set; }
        private readonly IMapper _mapper;
        private readonly TrashSystemDbContext _dbContext;

        public CreateContainerCommand(TrashSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var container = _dbContext.Container.SingleOrDefault(c => c.ContainerName == Model.ContainerName);
            container = _mapper.Map<Container>(Model);

            _dbContext.Container.Add(container);
            _dbContext.SaveChanges();
        }
        public class CreateContainerModel
        {
            public string ContainerName { get; set; }
            [Column(TypeName = "decimal(10, 6)")]
            public decimal Latitude { get; set; }
            [Column(TypeName = "decimal(10, 6)")]
            public decimal Longitude { get; set; }
            public int VehicleId { get; set; }
        }
    }
}
