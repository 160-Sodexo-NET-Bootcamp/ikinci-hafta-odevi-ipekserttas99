using Data_Homework_.Generic;
using Data_Homework_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data_Homework_.Operations.CreateContainerCommand;
using static Data_Homework_.Operations.UpdateCommands.UpdateContainerCommand;

namespace Data_Homework_.ContainerRepo
{
    public interface IContainerRepository : IGenericRepository<Container>
    {
        CreateContainerModel Create(CreateContainerModel createContainerModel);
        UpdateContainerModel Update(int id, UpdateContainerModel updateContainerModel);
    }
}
