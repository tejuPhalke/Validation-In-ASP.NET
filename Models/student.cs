using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace validationmethod.Models
{
    public class student
    {
        [Required]
        [Display(Name="StuId")]
        public int Id { get; set; }
        [Required]
        [Display(Name="StuName")]
        [StringLength(20, MinimumLength = 5, ErrorMessage="Extend the length")]
        public string Name { get; set; }
        [Required]
        [Display(Name="StuEmail")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$",ErrorMessage="Invalid Email Format")]
        public string Email { get; set; }
        [Required]
        [Display(Name="StuPassword")]
        [RegularExpression("[A-Za-z\\d@$!%*?&]{8,}",ErrorMessage="Invalid Email must contain at least 8 character")]
        public string Password { get; set; }
        [Required]
        [Display(Name="ConPassword")]
        [Compare("Password",ErrorMessage="Password Not Match")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.Duration)]
        public string VisitDate { get; set; }
        [Required]
        [Display(Name ="StuAge")]
        [Range(18,30,ErrorMessage ="Age Not valid")]
        public int? _age;



    }
}