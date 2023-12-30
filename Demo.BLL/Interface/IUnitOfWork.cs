using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interface
{
    public interface IUnitOfWork
    {
        public IEmployee Employee { get; set; }
        public IDepartment Department { get; set; }
        Task<int> complit();

        void Dispose();
    }
}
