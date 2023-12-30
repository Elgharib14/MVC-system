using Demo.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interface
{
    public interface IGeneric<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        Task Create(T obj);
        void Delet(T obj);
        void Update(T obj);
    }
}
