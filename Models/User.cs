using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppStore.Models
{
    public class User
    {
        
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        [Required]
        [Key]
        public int IdUser { get;  set; }
        [StringLength(20)]
        [Required]
        public string Username { get; set; }
        
        [Required]
        [EmailAddress]
        //[Remote("IsEmailExists","Account",ErrorMessage ="Email exists")]
        public string Email { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public string ErrorMessage { get; set; }
    }
}