using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    //Html Validation for Author
    class UserValidation
    { 
         [Required(ErrorMessage = "First Name is blank")]
         public string first_name { get; set; }

         [Required(ErrorMessage = "Last Name is blank")]
         public string last_name { get; set; }

         [Required(ErrorMessage = "Profile is blank")]
         public string profile { get; set; }

         [Required(ErrorMessage ="Email is blank")]
         [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Email incorrect")]
         public string email { get; set; }

        [Required(ErrorMessage ="Password is blank")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Password should be between 6 and 20 characters")]
         public string password { get; set; }

    }
    //partial: you can divide the same class in different files
    [MetadataType(typeof(UserValidation))]
    //indicating that validation of user properties
    //will take place in the UserValidation class
    public partial class author
    {

    }
}
