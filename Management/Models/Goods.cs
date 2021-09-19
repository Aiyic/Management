using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Management.Models.Goods
{
    public enum GoodType
    {
        [Display(Name = "借用品")]
        借用品 = 0,
        [Display(Name = "消耗品")]
        消耗品 = 1
    }

    public class Goods
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "商品编号")]
        public int GoodsId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        [Display(Name = "商品名称")]
        public string GoodsName { get; set; }
        [Required]
        [Range(0, 10000000)]
        [Display(Name = "商品数量")]
        public int GoodsNum { get; set; }
        [Required]
        [Range(0, 100000000)]
        [Display(Name = "商品单价")]
        public double GoodsPrice { get; set; }

        [Required]
        [Display(Name = "商品类别")]
        public GoodType GoodsType { get; set; }  

        [Display(Name = "商品购买日期")]
        public DateTime GoodsBuyTime { get; set; }
    }
    
}