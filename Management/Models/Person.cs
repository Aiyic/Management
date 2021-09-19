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
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "账户编号")]
        public int PersonId { get; set; }

        [Required]
        [Display(Name = "密码")]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "电话")]
        public long Phone { get; set; }
        [Required]
        [Display(Name = "部门")]
        public string Department { get; set; }

        [Display(Name = "是否为管理员")]
        public bool IsAdminister { get; set; }

    }
    
}
