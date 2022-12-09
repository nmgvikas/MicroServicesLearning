using MyCustomers.Management.App.CustomValidatiors;
using System.ComponentModel.DataAnnotations;
namespace MyCustomers.Management.App.Models
{
    public class Customer
    {
        public string _Id { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Name is too long or short")]
        public string Name { get; set; }

        [Required]
        //you might want to a look up validation with a place name (integrated with map service)
        public string Location { get; set; }

        [NotInFutureDateValidator]
        [DataType(DataType.Date)]
        public DateTime CustomerSince { get; set; }

        [DataType(DataType.Currency)]
        public double TotalPurchases { get; set; }
    }
}
