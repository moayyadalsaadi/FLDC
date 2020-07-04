namespace Graduation_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutCenters",
                c => new
                    {
                        AboutCenterId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AboutCenterId);
            
            CreateTable(
                "dbo.Applicant",
                c => new
                    {
                        ApplicantId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(),
                        University = c.String(),
                        College = c.String(nullable: false),
                        Section = c.String(nullable: false),
                        Degree = c.String(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        SSN = c.String(),
                        State = c.Int(),
                        JobState = c.String(),
                        Form = c.String(),
                        Payment = c.String(),
                        Status = c.String(),
                        CourseStart = c.DateTime(storeType: "date"),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicantId)
                .ForeignKey("dbo.course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CourseType = c.Int(nullable: false),
                        Description = c.String(),
                        SeatNumber = c.Int(nullable: false),
                        SeatBooked = c.Int(),
                        DateStart = c.DateTime(storeType: "date"),
                        DateEnd = c.DateTime(storeType: "date"),
                        ShowHide = c.Int(),
                        CourseDays = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.CenterAchievements",
                c => new
                    {
                        CenterAchievementId = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false),
                        Text = c.String(),
                        Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CenterAchievementId);
            
            CreateTable(
                "dbo.CenterPhotoes",
                c => new
                    {
                        CenterPhotosId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.CenterPhotosId);
            
            CreateTable(
                "dbo.CenterRules",
                c => new
                    {
                        CenterRuleId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CenterRuleId);
            
            CreateTable(
                "dbo.CenterStaffs",
                c => new
                    {
                        CenterStaffId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Path = c.String(),
                        Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CenterStaffId);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        ContactUsId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Phone = c.String(),
                        Mobile = c.String(),
                    })
                .PrimaryKey(t => t.ContactUsId);
            
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        FAQId = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.FAQId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        NewsContent = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NewsId);
            
            CreateTable(
                "dbo.PresidentWords",
                c => new
                    {
                        PresidentWordId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Text = c.String(),
                        Path = c.String(),
                        Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PresidentWordId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Applicant", "CourseId", "dbo.course");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Applicant", new[] { "CourseId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PresidentWords");
            DropTable("dbo.News");
            DropTable("dbo.FAQs");
            DropTable("dbo.ContactUs");
            DropTable("dbo.CenterStaffs");
            DropTable("dbo.CenterRules");
            DropTable("dbo.CenterPhotoes");
            DropTable("dbo.CenterAchievements");
            DropTable("dbo.course");
            DropTable("dbo.Applicant");
            DropTable("dbo.AboutCenters");
        }
    }
}
