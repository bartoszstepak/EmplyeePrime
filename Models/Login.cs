using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace crud_2.Models
{
    public class Login
    {
        public Login(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        [Key]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public string login { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public string password { get; set; }
        
    }
}
