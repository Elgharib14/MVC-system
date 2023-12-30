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
    public class GenericRep<T> : IGeneric<T> where T : class
    {
        
            private readonly AppDbContext context;

            public GenericRep(AppDbContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<T>> GetAll()
            {
            if(typeof(T) == typeof(Employee))
              return  (IEnumerable<T>)await context.Employees.Include(d=>d.Department).ToListAsync();
            else
                return await context.Set<T>().ToListAsync();

            }
            public async Task Create(T obj)
            {
                var data =  await context.Set<T>().AddAsync(obj);
              
            }
            public async Task<T> GetById(int id)
            {
                var data =await context.Set<T>().FindAsync(id);
                return data;
            }

            public void Update(T obj)
            {
            //if (typeof(T) == typeof(Employee))
            //{
            //    context.Employees.Include(d => d.Department).ToList();
            //}
            context.Set<T>().Update(obj);
                
            }

            public void Delet(T obj)
            {
                context.Set<T>().Remove(obj);
               
            }
        }
}
