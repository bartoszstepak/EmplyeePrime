using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace crud_2.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public string login { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string password { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public string firstName { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public string secondName { get; set; }
        [Column(TypeName = "varbinary(MAX)")]
        public byte[] image { get; set; }
    }
}
