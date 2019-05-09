using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace DataNotationValidationDemo
{
    public class BankAccount
    {

        public enum AccountType
        {
            Saving,
            Current
        }

        [Required(ErrorMessage="First Name Required")]
        [MaxLength(15,ErrorMessage="First Name should not more than 1`5 character")]
        [MinLength(3,ErrorMessage="First Name should be more than 3 character")]
        public string AccountHolderFirstName { get; set; }

        [Required(ErrorMessage="Last Name Required")]
        [MaxLength(15,ErrorMessage="Last Name should not more than 1`5 character")]
        [MinLength(3,ErrorMessage="Last Name should be more than 3 character")]
        public string AccountHolderLastName { get; set; }

        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Only Number allowed in AccountNumber")]
        public string AccountNumber { get; set; }

        [Required]
        public AccountType AcType { get; set; }

        public double AccountBalance { get; set; }
    }
}
