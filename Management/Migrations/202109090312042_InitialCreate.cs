namespace Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        GoodsId = c.Int(nullable: false, identity: true),
                        GoodsName = c.String(nullable: false, maxLength: 50),
                        GoodsNum = c.Int(nullable: false),
                        GoodsPrice = c.Double(nullable: false),
                        GoodsBuyTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GoodsId)
                .Index(t => t.GoodsName, unique: true);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.Long(nullable: false),
                        Department = c.String(nullable: false),
                        IsAdminister = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        GoodId = c.Int(nullable: false),
                        OperationNum = c.Int(nullable: false),
                        OperationType = c.Int(nullable: false),
                        OperationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Goods", new[] { "GoodsName" });
            DropTable("dbo.Records");
            DropTable("dbo.People");
            DropTable("dbo.Goods");
        }
    }
}
