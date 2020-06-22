using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TestAppService.Models.Extended;
using TestAppService.Models;

namespace TestAppService.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
        public string ConfirmPassword { get; set; }
        public bool Tradesman { get; set; }

        public virtual ICollection<Services> Services { get; set; }
        //public virtual ICollection<Advertisment> Advertisment { get; set; }
        public virtual ICollection<UserProfesion> UserProfesions { get; set; }

    }

    public class UserMetaData
    {
            [Display(Name="First Name")]
            [Required(AllowEmptyStrings =false,ErrorMessage ="Wprowadź imię")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Wprowadź nazwisko")]
            public string LastName { get; set; }

            [Display(Name ="Email")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Wprowadź email")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Display(Name = "Date of birth")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:MM/dd/yyyy}")]
            public Nullable<System.DateTime> DateOfBirth { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Wprowadź hasło")]
            [DataType(DataType.Password)]
            [MinLength(6,ErrorMessage ="Wprowadź przynajmniej 6 znaków")]
            public string Password { get; set; }

            [Display(Name = "Powtórz hasło")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Powtórzone hasło jest nieprawidłowe")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Tradesman")]
            public bool Tradesman { get; set; }

        //    public bool IsEmailVerified { get; set; }
        //   public System.Guid ActivationCode { get; set; }
    }
    }


