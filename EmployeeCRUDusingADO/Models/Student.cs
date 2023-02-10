using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeCRUDusingADO.Models
{
    [Table("tblStudent")]
    public class Student
    {
       
     
            [Key]
            [ScaffoldColumn(false)]

            public int Id { get; set; }

            [Required]
            [Display(Name = "Student Name")]
            [MaxLength(40)]
            [MinLength(2)]
            public string? Name { get; set; }

            [Required]
            [MaxLength(10)]
            public string? Mobile { get; set; }

            [Required]
            [MaxLength(40)]
            public string? Email { get; set; }

            [Required]
            [MaxLength(40)]
            public string? City { get; set; }

            [Required]
            public string? Gender { get; set; }

            [Required]
            public double Fees { get; set; }

            [ScaffoldColumn(false)]
            public int IsActive { get; set; }

        
    }
}
