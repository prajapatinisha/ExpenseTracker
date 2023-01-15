namespace Project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CatId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        CatExpLimit = c.Int(nullable: false),
                        ExpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CatId)
                .ForeignKey("dbo.Expenses", t => t.ExpId, cascadeDelete: true)
                .Index(t => t.ExpId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 40),
                        Description = c.String(),
                        Amount = c.Int(nullable: false),
                        Category = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ExpId);
            
            CreateTable(
                "dbo.ExpenseLimits",
                c => new
                    {
                        ExpLimitId = c.Int(nullable: false, identity: true),
                        TotExpLimit = c.Int(nullable: false),
                        ExpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpLimitId)
                .ForeignKey("dbo.Expenses", t => t.ExpId, cascadeDelete: true)
                .Index(t => t.ExpId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseLimits", "ExpId", "dbo.Expenses");
            DropForeignKey("dbo.Categories", "ExpId", "dbo.Expenses");
            DropIndex("dbo.ExpenseLimits", new[] { "ExpId" });
            DropIndex("dbo.Categories", new[] { "ExpId" });
            DropTable("dbo.ExpenseLimits");
            DropTable("dbo.Expenses");
            DropTable("dbo.Categories");
        }
    }
}
