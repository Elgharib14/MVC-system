using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Range(22,30)]
        public int? Age { get; set; }
        [Required]
        public float Salary { get; set; }
        public DateTime HireTime { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public bool IsACtive { get; set; }
        public string? Notes { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Adders { get; set; }
        public string ImageName { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
       
    }
}
