using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testApp.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string lastname { get; set; }

        [Required]
        public int age { get; set; }

        public enum gender { Male , Female }
        [Required]
        public gender Gender { get; set; }

        //create Confirm Password field in order to create a better UX.
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }


}
