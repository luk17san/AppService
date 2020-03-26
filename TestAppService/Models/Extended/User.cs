using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestAppService.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
        public string ConfirmPassword { get; set; }

    }

    public class UserMetaData
    {
            [Display(Name="First Name")]
            [Required(AllowEmptyStrings =false,ErrorMessage ="First name required")]
            public string First_Name { get; set; }

            [Display(Name = "Last Name")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
            public string Last_Name { get; set; }

            [Display(Name ="Email ID")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
            [DataType(DataType.EmailAddress)]
            public string Email_ID { get; set; }

            [Display(Name = "Date of birth")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:MM/dd/yyyy}")]
            public Nullable<System.DateTime> DateOfBirth { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            [MinLength(6,ErrorMessage ="Minimum 6 characters required")]
            public string Password { get; set; }

            [Display(Name = "Confirm Password")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
            public string ConfirmPassword { get; set; }

        //    public bool IsEmailVerified { get; set; }
         //   public System.Guid ActivationCode { get; set; }
        }
    }