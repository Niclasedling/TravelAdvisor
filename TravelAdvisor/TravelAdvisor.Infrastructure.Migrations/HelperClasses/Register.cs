using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAdvisor.Infrastructure.Migrations.HelperClasses
{
    public class Register
    {
        [Required(ErrorMessage = "Email is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwrod is not matching")]
        public string ConfirmPassword { get; set; }
    }
}
