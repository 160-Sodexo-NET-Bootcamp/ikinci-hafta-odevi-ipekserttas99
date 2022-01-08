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

        private readonly TrashSystemDbContext _dbContext;

        public CreateContainerCommand(TrashSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var container = _dbContext.Container.SingleOrDefault(c => c.ContainerName == Model.ContainerName);
            if (container is not null)
                throw new InvalidOperationException("Container zaten mevcut");

            container = new Container();
            container.ContainerName = Model.ContainerName;
            container.Latitude = Model.Latitude;
            container.Longitude = Model.Longitude;
            container.VehicleId = Model.VehicleId;

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
