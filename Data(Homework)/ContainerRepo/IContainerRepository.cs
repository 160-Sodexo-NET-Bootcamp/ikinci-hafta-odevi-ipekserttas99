using Data_Homework_.Generic;
using Data_Homework_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Homework_.ViewModels;

namespace Data_Homework_.ContainerRepo
{
    public interface IContainerRepository : IGenericRepository<Container>
    {
        Task Create(CreateContainerViewModel createContainerModel);
        Task Update(int id, UpdateContainerViewModel updateContainerModel);
    }
}
