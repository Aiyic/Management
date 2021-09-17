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
            AutomaticMigrationDataLossAllowed = true;//允许数据丢失,默认生成时没有这一项（不添加这一项时，只在添加/删除实体类时自动生成，如果我们删除了实体类的一个属性就会抛出异常）

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
                    Phone = 279, Department = "g340", IsAdminister = false}
            };

            persons.ForEach(s => context.Persons.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var goods = new List<Goods>
            {
                new Goods {GoodsName = "Pen", GoodsNum = 10, GoodsPrice = 5, GoodsType = GoodType.Consumption, GoodsBuyTime =  DateTime.Parse("2021-09-08")},
                new Goods {GoodsName = "A4 Paper", GoodsNum = 10000, GoodsPrice = 0.01, GoodsType = GoodType.Consumption, GoodsBuyTime =  DateTime.Parse("2021-09-08")},
                new Goods {GoodsName = "Disktop Folder", GoodsNum = 100, GoodsPrice = 9.9, GoodsType = GoodType.Borrow, GoodsBuyTime =  DateTime.Parse("2021-09-08")},
                new Goods {GoodsName = "Calculator", GoodsNum = 100, GoodsPrice = 19.9, GoodsType = GoodType.Borrow, GoodsBuyTime =  DateTime.Parse("2021-09-08")},
                new Goods {GoodsName = "Scissors", GoodsNum = 10, GoodsPrice = 4.8, GoodsType = GoodType.Borrow, GoodsBuyTime =  DateTime.Parse("2021-09-08")}
            };
            goods.ForEach(s => context.Goods.AddOrUpdate(p => p.GoodsName, s));
            context.SaveChanges();

        }
    }
}
