using Demo.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interface
{
    public interface IEmployee : IGeneric<Employee>
    {

        public IQueryable<Employee> SearchEmployees(string obj);
    }
}
