using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace crud_2.Models
{
    public class MyTask
    {

        [Key]
        public int id { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required]
        public string title { get; set; }

        [Column(TypeName = "nvarchar(1024)")]
        public string content { get; set; }

        [Column(TypeName = "integer")]
        [Required]
        public int status { get; set; }

        [Column(TypeName = "integer")]
        [Required]
        public int createdBy { get; set; }

        [Column(TypeName = "integer")]
        [Required]
        public int assignedTo { get; set; }

        
    }
}
