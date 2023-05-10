using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace studentRegistration.Models
{
    public class customUser
    {

        [Key]
        public int uId { get; set; }

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

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "Enter your first name")]
        public string fName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Enter your last name")]
        public string lName { get; set; }

    }

}