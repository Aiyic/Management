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
        [Display(Name = "借用")]
        Borrow =0,
        [Display(Name = "消耗")]
        Consumption =1,
        [Display(Name = "归还")]
        Return =2
    }
    
    public class Record
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "记录编号")]
        public int RecordId { get; set; }
        
        [Required]
        [Display(Name = "用户编号")]
        public int PersonId { get; set; }
        [Required]
        [Display(Name = "商品编号")]
        public int GoodId { get; set; }
        [Required]
        [Range(0,10000000)]
        [Display(Name = "操作数目")]
        public int OperationNum { get; set; }

        [Required]
        [Display(Name = "操作类型")]
        public OpType OperationType { get; set; }  //0:jie 1:huan 2:xiaohao

        [Display(Name = "记录时间")]
        public DateTime OperationTime { get; set; }
    }
    
}