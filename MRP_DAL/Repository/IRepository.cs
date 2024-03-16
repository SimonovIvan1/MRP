using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP_DAL.Repository
{
    interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Guid id); 
        Task Create(T item); 
        Task Update(T item);
        Task Delete(Guid id); 
        Task Save();  
    }
}
