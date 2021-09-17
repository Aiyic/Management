using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Management.Models.Goods
{
    public enum GoodsType
    {
        [Display(Name = "Borrow")]
        Borrow = 0,
        [Display(Name = "Consumption")]
        Consumption = 1
    }

    public class Goods
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GoodsId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string GoodsName { get; set; }
        [Required]
        [Range(0, 10000000)]
        public int GoodsNum { get; set; }
        [Required]
        [Range(0, 100000000)]
        public double GoodsPrice { get; set; }

        [Required]
        public GoodsType GoodsType { get; set; }

        public DateTime GoodsBuyTime { get; set; }
    }
    
}