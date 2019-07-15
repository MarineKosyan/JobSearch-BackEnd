namespace Benivo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmploymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Company = c.String(),
                        CategoryId = c.Int(nullable: false),
                        EmploymentTypeId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        IsBooked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.EmploymentTypes", t => t.EmploymentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.EmploymentTypeId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Jobs", "EmploymentTypeId", "dbo.EmploymentTypes");
            DropForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "LocationId" });
            DropIndex("dbo.Jobs", new[] { "EmploymentTypeId" });
            DropIndex("dbo.Jobs", new[] { "CategoryId" });
            DropTable("dbo.Locations");
            DropTable("dbo.Jobs");
            DropTable("dbo.EmploymentTypes");
            DropTable("dbo.Categories");
        }
    }
}
