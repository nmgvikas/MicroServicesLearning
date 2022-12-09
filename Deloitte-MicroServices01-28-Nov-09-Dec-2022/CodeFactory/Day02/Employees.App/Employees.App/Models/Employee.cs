using System.ComponentModel.DataAnnotations;

namespace Employees.App.Models
{
    //POCO Class
    //Decorated with Annotations
    //Annotations can be used for Data Definitions, Validation, Formatting, ErrorMessages

    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(minimum:10000,maximum:100000)]
        [DataType(DataType.Currency)]
        public double Salary { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfJoin { get; set; }

        public string City { get; set; }
    }
}
