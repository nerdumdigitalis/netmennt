namespace Netmennt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentId = c.Int(nullable: false, identity: true),
                        EnrolleeId = c.Int(nullable: false),
                        EnrolledId = c.Int(nullable: false),
                        EnrolledType = c.Int(nullable: false),
                        EnrolleeType = c.Int(nullable: false),
                        DateStart = c.DateTime(precision: 7, storeType: "datetime2"),
                        DateEnd = c.DateTime(precision: 7, storeType: "datetime2"),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentId);
            
            CreateTable(
                "dbo.Flermigans",
                c => new
                    {
                        FlermiganId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        MyProperty = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Type = c.Int(nullable: false),
                        VideoUrl = c.String(),
                        ImagePath = c.String(),
                        Order = c.Int(nullable: false),
                        EnrollmentGuid = c.String(),
                    })
                .PrimaryKey(t => t.FlermiganId);
            
            CreateTable(
                "dbo.UserProgressDatas",
                c => new
                    {
                        UserProgressDataId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        DataReferenceId = c.Int(nullable: false),
                        DataReferenceType = c.Int(nullable: false),
                        Progress = c.Int(nullable: false),
                        Result = c.Int(nullable: false),
                        DateStarted = c.DateTime(precision: 7, storeType: "datetime2"),
                        DateCompleted = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.UserProgressDataId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Nationality = c.String(),
                        Registered = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Name = c.String(),
                        ReferenceId = c.String(),
                        Address = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.UserProgressDatas");
            DropTable("dbo.Flermigans");
            DropTable("dbo.Enrollments");
        }
    }
}
