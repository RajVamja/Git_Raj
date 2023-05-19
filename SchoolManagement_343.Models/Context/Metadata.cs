using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace SchoolManagement_343.Models.Context
{


    [MetadataType(typeof(Metadata))]
    public partial class Subject
    {
        internal class Metadata
        {
            [Required]
            public int subId { get; set; }

            [Required(ErrorMessage = "Please enter the subject!")]
            [MinLength(2, ErrorMessage = "Please enter valid subject name!")]
            [StringLength(10, ErrorMessage = "Subject Name length should be maintain (ex. max length 10)")]
            public string subName { get; set; }
        }
    }


    [MetadataType(typeof(Metadata))]
    public partial class Country
    {
        internal class Metadata
        {
            [Key]
            public int cId { get; set; }

            [Required(ErrorMessage = "Please enter the country!")]
            [MinLength(4, ErrorMessage = "Please enter valid country name!")]
            [StringLength(20, ErrorMessage = "Country Name length should be maintain (ex. max length 20)")]
            public string cName { get; set; }
        }
    }

    [MetadataType(typeof(Metadata))]
    public partial class State
    {
        internal class Metadata
        {
            [Key]
            public int sId { get; set; }

            [Required(ErrorMessage = "Please enter the State!")]
            [MinLength(4, ErrorMessage = "Please enter valid State name!")]
            [StringLength(20, ErrorMessage = "State Name length should be maintain (ex. max length 20)")]
            public string sName { get; set; }

            [Key]
            public Nullable<int> cId { get; set; }
        }
    }


    [MetadataType(typeof(Metadata))]
    public partial class City

    {
        internal class Metadata
        {
            [Key]
            public int cityId { get; set; }

            [Required(ErrorMessage = "Please enter the city!")]
            [MinLength(4, ErrorMessage = "Please enter valid city name!")]
            [StringLength(20, ErrorMessage = "City Name length should be maintain (ex. max length 20)")]
            public string cityName { get; set; }

            [Key]
            public Nullable<int> sId { get; set; }

            [Key]
            public Nullable<int> cId { get; set; }
        }
    }


    [MetadataType(typeof(Metadata))]
    public partial class teacher

    {
        internal class Metadata
        {
            [Key]
            public int tId { get; set; }

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


            [Required(ErrorMessage = "Please select your DOB")]
            public System.DateTime DOB { get; set; }


            [Required(ErrorMessage = "Please enter your contact number")]
            [Display(Name = "Enter your contact number")]
            [RegularExpression(@"[0-9]{10}", ErrorMessage = "Mobile number must be 10 digit and only numbers")]
            public string tPhone { get; set; }


            [Required(ErrorMessage = "Please enter your username")]
            [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
            [Display(Name = "Enter your email")]
            public string tEmail { get; set; }

            [Required(ErrorMessage = "Please select Gender type")]
            [Display(Name = "Select your gender type")]
            public string Gender { get; set; }

            [Required(ErrorMessage = "Please enter your Address")]
            [Display(Name = "Enter your Address")]
            public string aAddress { get; set; }


            [Required(ErrorMessage = "Select your subjects")]
            [Display(Name = "Select your subjects")]
            public string subjects { get; set; }


            [Required(ErrorMessage = "Select your city")]
            public int city { get; set; }

            [Required(ErrorMessage = "Select your state")]
            public int state { get; set; }

            [Required(ErrorMessage = "Select your country")]
            public int country { get; set; }
        }
    }


    [MetadataType(typeof(Metadata))]

    public partial class student

    {

        internal class Metadata
        {
            [Key]
            public int stdId { get; set; }

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


            [Required(ErrorMessage = "Please select your DOB")]
            public System.DateTime DOB { get; set; }


            [Required(ErrorMessage = "Please enter your contact number")]
            [RegularExpression(@"[0-9]{10}", ErrorMessage = "Mobile number must be 10 digit and only numbers")]
            [Display(Name = "Enter your contact number")]
            public string sPhone { get; set; }


            [Required(ErrorMessage = "Please enter your username")]
            [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
            [Display(Name = "Enter your email")]
            public string sEmail { get; set; }

            [Required(ErrorMessage = "Please select Gender type")]
            [Display(Name = "Select your gender type")]
            public string Gender { get; set; }

            [Required(ErrorMessage = "Please enter your Address")]
            [Display(Name = "Enter your Address")]
            public string sAddress { get; set; }


            [Required(ErrorMessage = "Select your teacher")]
            [Display(Name = "Select your teachers")]
            public string teacher { get; set; }


            [Required(ErrorMessage = "Select your city")]
            public int city { get; set; }

            [Required(ErrorMessage = "Select your state")]
            public int state { get; set; }

            [Required(ErrorMessage = "Select your country")]
            public int country { get; set; }

            [Required(ErrorMessage = "Select your student type")]
            public int studentType { get; set; }
        }
        public EType studentTypeE { get; set; }

        public enum EType
        {
            Hosteller = 0, 
            DayScholar = 1
        }
    }
}

