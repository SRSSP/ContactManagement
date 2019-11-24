using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessAccessLayer
{
    public class ContactEntity
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage = "Please enter FirstName")]
        [StringLength(10, ErrorMessage = "Maximum length is exceeded")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter LatName")]
        [StringLength(10, ErrorMessage = "Maximum length is exceeded")]
        public string LastName { get; set; }
        [RegularExpression("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$", ErrorMessage = "Doesn't look like a valid email")]
        [Required(ErrorMessage = "Please enter EmailId")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter PhoneNumber")]
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}
