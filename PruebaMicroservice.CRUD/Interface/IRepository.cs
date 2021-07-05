using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservice.CRUD.Interface
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int Id);
        public Task<T> Add(T _object);
        public Task<bool> Update(T _object);
        public Task<bool> Delete(int Id);
    }
}
