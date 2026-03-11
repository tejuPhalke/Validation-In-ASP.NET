using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace validationmethod.Models
{
    public class User
    {
        [Required]
         public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string Cpassword { get; set; }
        [Required]
        public string phone { get; set; }

    }
}