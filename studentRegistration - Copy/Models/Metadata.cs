using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;

using System.ComponentModel.DataAnnotations;

namespace studentRegistration.Models
{

    [MetadataType(typeof(Metadata))]
    public partial class student
    {
        internal class Metadata
        {
            [Required]
            public int stdId { get; set; }

            [Required(ErrorMessage = "Please enter your first name")]
            [Display(Name = "Enter your first name")]
            public string fName { get; set; }

            [Required(ErrorMessage = "Please enter your last name")]
            [Display(Name = "Enter your last name")]
            public string lName { get; set; }

            [Required(ErrorMessage = "Please select your DOB")]
            public string DOB { get; set; }

            [Required(ErrorMessage = "Please enter your contact number")]
            [MinLength(10, ErrorMessage ="contact number should have only 10 digits!")]
            [MaxLength(10, ErrorMessage = "contact number should have only 10 digits!")]
            [Display(Name = "Enter your contact number")]
            public string sPhone { get; set; }

            [Required(ErrorMessage = "Please enter your username")]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Enter your email")]
            public string sEmail { get; set; }

            [Required(ErrorMessage = "Please select Gender type")]
            [Display(Name = "Select your gender type")]
            public string Gender { get; set; }

            [Required(ErrorMessage = "Please enter your Address")]
            [Display(Name = "Enter your Address")]
            public string sAddress { get; set; }

            [Required(ErrorMessage = "Select your city")]
            public int city { get; set; }

            [Required(ErrorMessage = "Select your state")]
            public int state { get; set; }


            [Display(Name = "Select your Country, State and City")]
            [Required(ErrorMessage = "Select your country")]
            public int country { get; set; }

        }
    }
}