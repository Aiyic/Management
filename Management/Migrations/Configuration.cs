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
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(Management.Models.ManagementDBContext context)
        //{
        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data. E.g.
        //
        //    context.People.AddOrUpdate(
        //      p => p.FullName,
        //      new Person { FullName = "Andrew Peters" },
        //      new Person { FullName = "Brice Lambson" },
        //      new Person { FullName = "Rowan Miller" }
        //    );
        //}
        
        protected override void Seed(Management.Models.ManagementDBContext context)
        {
            var persons = new List<Person>
            {
                new Person { PersonId = 10000, Password = "admin", Name = "admin",
                    Phone = 110, Department = "Xidian", IsAdminister = true},
                new Person { PersonId = 10001, Password = "10001", Name = "first_user",
                    Phone = 120, Department = "g336", IsAdminister = false}
            };

            persons.ForEach(s => context.Persons.AddOrUpdate(p => p.PersonId, s));
            context.SaveChanges();

            var goods = new List<Goods>
            {
                new Goods {GoodsId = 10000, GoodsName = "Pen", GoodsNum = 10, GoodsPrice = 5, GoodsBuyTime =  DateTime.Parse("2021-09-08")},
                new Goods {GoodsId = 10001, GoodsName = "Paper", GoodsNum = 10000, GoodsPrice = 0.01, GoodsBuyTime =  DateTime.Parse("2021-09-08")}
            };
            goods.ForEach(s => context.Goods.AddOrUpdate(p => p.GoodsId, s));
            context.SaveChanges();
            
        }
    }
}