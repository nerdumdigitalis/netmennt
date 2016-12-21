namespace Netmennt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatorIdInFlermigan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flermigans", "CreatorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flermigans", "CreatorId");
        }
    }
}
