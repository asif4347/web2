namespace WebProgrammingPhase2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminContacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Education = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        jobTiltile = c.String(nullable: false),
                        Skills = c.String(nullable: false),
                        Rating = c.String(),
                        isTop5 = c.String(),
                        isHired = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HRPersonnels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(nullable: false),
                        shortDes = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        Position = c.String(nullable: false),
                        RequiredSkills = c.String(nullable: false),
                        ApplyTill = c.DateTime(nullable: false),
                        LongDes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HRPersonnels");
            DropTable("dbo.Applicants");
            DropTable("dbo.AdminContacts");
        }
    }
}
