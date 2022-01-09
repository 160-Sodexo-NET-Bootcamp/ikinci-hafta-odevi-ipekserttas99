using Data_Homework_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.Generic
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        
        Task<TEntity> GetById(int id);
        List<List<Container>> GetClusteredContainers(List<Container> containers, int N);

        //Task Create(TEntity entity);
        //Task Update(int id, TEntity entity);

        Task Delete(int id);
    }
}
