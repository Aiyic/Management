using Management.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Management.Models
{
    public class ManagementDBContext : DbContext
    {
        public DbSet<Goods.Goods> Goods { get; set; }
        public DbSet<Person.Person> Persons { get; set; }
        public DbSet<Record.Record> Records { get; set; }

        public ManagementDBContext()
        {
            //添加MigrateDatabaseToLatestVersion数据库初始化器
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ManagementDBContext, Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}