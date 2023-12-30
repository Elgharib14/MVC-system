using Demo.BLL.Interface;
using Demo.DAL.context;
using Demo.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Reposatory
{
    public class EmployeeRep : GenericRep<Employee>, IEmployee
    {
        private readonly AppDbContext context;

        public EmployeeRep(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable<Employee> SearchEmployees (string employeeName)
        {
            return context.Employees.Where(e => e.Name == employeeName);
        }
    }
}
