using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Management.Models.Person;
using Management.Models.Goods;

namespace Management.Models.Record
{
    public enum OpType {Borrow, Return, Consumption }

    public class Record
    {
        [Key]
        public int RecordId { get; set; }
        
        [Required]
        public int PersonId { get; set; }
        [Required]
        public int GoodId { get; set; }
        [Required]
        public int OperationNum { get; set; }

        [Required]
        public OpType OperationType { get; set; }  //0:jie 1:huan 2:xiaohao

        public DateTime OperationTime { get; set; }
    }

    public class ManagementDBContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
    }

}