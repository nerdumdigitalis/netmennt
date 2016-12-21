namespace Netmennt.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RenameFlermigan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Components",
                c => new
                {
                    ComponentId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Type = c.Int(nullable: false),
                    VideoUrl = c.String(),
                    ImagePath = c.String(),
                    Order = c.Int(nullable: false),
                    EnrollmentGuid = c.String(),
                    CreatorId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ComponentId);

            DropTable("dbo.Flermigans");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.Flermigans",
                c => new
                {
                    FlermiganId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Type = c.Int(nullable: false),
                    VideoUrl = c.String(),
                    ImagePath = c.String(),
                    Order = c.Int(nullable: false),
                    EnrollmentGuid = c.String(),
                    CreatorId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.FlermiganId);

            DropTable("dbo.Components");
        }
    }
}
