namespace Netmennt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropImagePath : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Components", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Components", "ImagePath", c => c.String());
        }
    }
}
