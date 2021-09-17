namespace Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_goods_type : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Records");
            AddColumn("dbo.Goods", "GoodsType", c => c.Int(nullable: false));
            AlterColumn("dbo.Records", "RecordId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Records", "RecordId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Records");
            AlterColumn("dbo.Records", "RecordId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Goods", "GoodsType");
            AddPrimaryKey("dbo.Records", "RecordId");
        }
    }
}
