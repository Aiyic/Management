namespace Management.Migrations
{
    using Management.Models;
    using Management.Models.Person;
    using Management.Models.Goods;
    using Management.Models.Record;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Management.Models.ManagementDBContext>
    {
        public Configuration()
        {
            // AutomaticMigrationsEnabled = false;

            AutomaticMigrationsEnabled = true;//自动迁移为true
            AutomaticMigrationDataLossAllowed = true;

        }
        
        protected override void Seed(Management.Models.ManagementDBContext context)
        {
            var persons = new List<Person>
            {
                new Person { Password = "admin", Name = "admin",
                    Phone = 110, Department = "Xidian", IsAdminister = true},
                new Person { Password = "llz", Name = "llz",
                    Phone = 260, Department = "g340", IsAdminister = false},
                new Person { Password = "hhb", Name = "hhb",
                    Phone = 252, Department = "g340", IsAdminister = false},
                new Person { Password = "lmz", Name = "lmz",
                    Phone = 238, Department = "g340", IsAdminister = false},
                new Person { Password = "zwz", Name = "zwz",
                    Phone = 248, Department = "g340", IsAdminister = false},
                new Person { Password = "lk", Name = "lk",
                    Phone = 279, Department = "g340", IsAdminister = false},
                new Person { Password = "马云", Name = "马云",
                    Phone = 279, Department = "阿里", IsAdminister = true},
                new Person { Password = "马化腾", Name = "马化腾",
                    Phone = 279, Department = "腾讯", IsAdminister = true}
            };

            persons.ForEach(s => context.Persons.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var goods = new List<Goods>
            {
                new Goods {GoodsName = "中性笔", GoodsNum = 100, GoodsPrice = 2, GoodsType = GoodType.消耗品, GoodsBuyTime =  DateTime.Parse("2021-09-08")},
                new Goods {GoodsName = "钢笔", GoodsNum = 10, GoodsPrice = 5, GoodsType = GoodType.借用品, GoodsBuyTime =  DateTime.Parse("2021-09-08")},
                new Goods {GoodsName = "A4纸", GoodsNum = 10000, GoodsPrice = 0.01, GoodsType = GoodType.消耗品, GoodsBuyTime =  DateTime.Parse("2021-09-08")},
                new Goods {GoodsName = "文件夹", GoodsNum = 100, GoodsPrice = 9.9, GoodsType = GoodType.借用品, GoodsBuyTime =  DateTime.Parse("2021-09-08")},
                new Goods {GoodsName = "计算机", GoodsNum = 100, GoodsPrice = 19.9, GoodsType = GoodType.借用品, GoodsBuyTime =  DateTime.Parse("2021-09-08")},
                new Goods {GoodsName = "剪刀", GoodsNum = 10, GoodsPrice = 4.8, GoodsType = GoodType.借用品, GoodsBuyTime =  DateTime.Parse("2021-09-08")},
                new Goods {GoodsName = "订书机", GoodsNum = 10, GoodsPrice = 9.8, GoodsType = GoodType.借用品, GoodsBuyTime =  DateTime.Parse("2021-09-08")},
                new Goods {GoodsName = "订书针", GoodsNum = 10000, GoodsPrice = 0.1, GoodsType = GoodType.消耗品, GoodsBuyTime =  DateTime.Parse("2021-09-08")}
            };
            goods.ForEach(s => context.Goods.AddOrUpdate(p => p.GoodsName, s));
            context.SaveChanges();

        }
    }
}
