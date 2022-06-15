using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebDesign.Data
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string RegNo { get; set; }
    }
}
