namespace Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_goods_type2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Records");
            AlterColumn("dbo.Records", "RecordId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Records", "RecordId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Records");
            AlterColumn("dbo.Records", "RecordId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Records", "RecordId");
        }
    }
}
