using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Models.Person
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public long Phone { get; set; }
        [Required]
        public string Department { get; set; }
        
        public bool IsAdminister { get; set; }

    }
    
}
