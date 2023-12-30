using Demo.DAL.Model;
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModel
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Code is Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "The Name is Required")]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime DateTimeCreation { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
