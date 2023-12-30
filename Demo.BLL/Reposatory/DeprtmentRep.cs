using Demo.BLL.Interface;
using Demo.DAL.context;
using Demo.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Reposatory
{
    public class DeprtmentRep : GenericRep<Department>, IDepartment
    {
        public DeprtmentRep(AppDbContext context) : base(context)
        {
        }
    }
}
