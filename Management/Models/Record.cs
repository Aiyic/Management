using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Management.Models.Person;
using Management.Models.Goods;
using System.Reflection;
using System.Web.Mvc;
using System.ComponentModel;

namespace Management.Models.Record
{
    public enum OpType
    {
        [Display(Name = "Borrow")]
        Borrow =0,
        [Display(Name = "Return")]
        Return =1,
        [Display(Name = "Consumption")]
        Consumption =2
    }
    
    public class Record
    {
        [Key]
        public int RecordId { get; set; }
        
        [Required]
        public int PersonId { get; set; }
        [Required]
        public int GoodId { get; set; }
        [Required]
        [Range(0,10000000)]
        public int OperationNum { get; set; }

        [Required]
        public OpType OperationType { get; set; }  //0:jie 1:huan 2:xiaohao

        public DateTime OperationTime { get; set; }
    }
    
}