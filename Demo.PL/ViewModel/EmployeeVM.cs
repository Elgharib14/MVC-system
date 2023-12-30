using Demo.DAL.Model;
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModel
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Range(22, 30)]
        public int? Age { get; set; }
       
        public float Salary { get; set; }
        public DateTime HireTime { get; set; }
       
        public bool IsACtive { get; set; }
        public string? Notes { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Adders { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

    }
}
