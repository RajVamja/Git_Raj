using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiRepo_Models.Model
{
    public class CustomUserModel
    {
        [Key]
        public int uId { get; set; }


        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "Enter your first name")]
        [MinLength(3)]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z]{3,10}$", ErrorMessage = "Name length within 3 to 10 characters & Kindly Enter only Alphabet")]
        public string fName { get; set; }


        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Enter your last name")]
        [MinLength(3)]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z]{3,10}$", ErrorMessage = "Name length within 3 to 10 characters & Kindly Enter only Alphabet")]
        public string lName { get; set; }


        [Required(ErrorMessage = "Please enter your username")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Enter your username")]

        public string userName { get; set; }


        [Display(Name = "Enter your password")]
        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password should have up to 8 letters")]
        public string passWord { get; set; }


        [Display(Name = "Re-Enter your password")]
        [Required(ErrorMessage = "Please re-enter your password")]
        [DataType(DataType.Password)]
        [Compare("passWord", ErrorMessage = "Your password doesn't match!")]
        public string confirm { get; set; }
    }
}
