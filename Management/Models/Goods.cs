using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Management.Models.Goods
{
    public class Goods
    {
        [Key]
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

        public DateTime GoodsBuyTime { get; set; }
    }
    
}