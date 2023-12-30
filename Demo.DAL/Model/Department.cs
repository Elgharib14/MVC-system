using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="The Code is Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "The Name is Required")]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime DateTimeCreation { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
