using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SustainableFarmingApp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName should not be empty")]
        public string Name {get;set;}
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName should not be empty")]
        public string Surname { get; set; }
       
        public int Identity { get; set; }
        
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName should not be empty")]
        public string Password  { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName should not be empty")]
        public string ConfirmPassword { get; set; }

    }
}
