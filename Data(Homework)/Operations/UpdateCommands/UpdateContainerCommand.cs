using Data_Homework_.Context;
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

        public UpdateContainerCommand(TrashSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(int id, UpdateContainerModel updateContainerModel)
        {
            var container = _dbContext.Container.SingleOrDefault(x => x.Id == id);
            if (container is null)
                throw new InvalidOperationException("Container bulunamadı");

            container.ContainerName = updateContainerModel.ContainerName != default ? updateContainerModel.ContainerName : container.ContainerName;
            container.Latitude = updateContainerModel.Latitude != default ? updateContainerModel.Latitude : container.Latitude;
            container.Longitude = updateContainerModel.Longitude != default ? updateContainerModel.Longitude : container.Longitude;
            
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
