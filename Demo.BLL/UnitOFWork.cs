using Demo.BLL.Interface;
using Demo.BLL.Reposatory;
using Demo.DAL.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL
{
    public class UnitOFWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public IEmployee Employee { get; set; }
        public IDepartment Department { get; set ; }

        public UnitOFWork(AppDbContext context)
        {
            Employee = new EmployeeRep(context);
            Department = new DeprtmentRep(context);
            this.context = context;
        }

        public async Task<int> complit()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
