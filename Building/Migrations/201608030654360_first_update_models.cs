namespace Building.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first_update_models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        Url = c.String(),
                        Info = c.String(),
                        MediaType = c.Int(nullable: false),
                        Belong_Id = c.Int(),
                        Creator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modules", t => t.Belong_Id)
                .ForeignKey("dbo.Users", t => t.Creator_Id)
                .Index(t => t.Belong_Id)
                .Index(t => t.Creator_Id);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        Info = c.String(),
                        Creator_Id = c.Int(),
                        Superior_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Creator_Id)
                .ForeignKey("dbo.Modules", t => t.Superior_Id)
                .Index(t => t.Creator_Id)
                .Index(t => t.Superior_Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        Content = c.String(),
                        Info = c.String(),
                        Author_Id = c.Int(),
                        Belong_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.Modules", t => t.Belong_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Belong_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        Password = c.String(),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Media", "Creator_Id", "dbo.Users");
            DropForeignKey("dbo.Modules", "Superior_Id", "dbo.Modules");
            DropForeignKey("dbo.Media", "Belong_Id", "dbo.Modules");
            DropForeignKey("dbo.Modules", "Creator_Id", "dbo.Users");
            DropForeignKey("dbo.Articles", "Belong_Id", "dbo.Modules");
            DropForeignKey("dbo.Articles", "Author_Id", "dbo.Users");
            DropIndex("dbo.Articles", new[] { "Belong_Id" });
            DropIndex("dbo.Articles", new[] { "Author_Id" });
            DropIndex("dbo.Modules", new[] { "Superior_Id" });
            DropIndex("dbo.Modules", new[] { "Creator_Id" });
            DropIndex("dbo.Media", new[] { "Creator_Id" });
            DropIndex("dbo.Media", new[] { "Belong_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Articles");
            DropTable("dbo.Modules");
            DropTable("dbo.Media");
        }
    }
}
