namespace Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unique_name : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.People", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.People", new[] { "Name" });
        }
    }
}
