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
    }
}