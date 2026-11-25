using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidationFilterDemo.Models
{
    public class UserInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [StringLength(10, MinimumLength = 3)]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Need to enter email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int Age { get; set; }
        [Required(ErrorMessage ="Need to enter phone number.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
