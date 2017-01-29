namespace WordChain.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BadWords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportedId = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        WordId = c.Int(nullable: false),
                        WordAuthor = c.String(),
                        Reporter_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Reporter_Id, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .ForeignKey("dbo.Words", t => t.WordId, cascadeDelete: true)
                .Index(t => t.TopicId)
                .Index(t => t.WordId)
                .Index(t => t.Reporter_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(nullable: false),
                        FullName = c.String(maxLength: 20),
                        Email = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AuthorId = c.String(),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId, cascadeDelete: false)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: false)
                .Index(t => t.AuthorId)
                .Index(t => t.TopicId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "WordId", "dbo.Words");
            DropForeignKey("dbo.Reports", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Reports", "Reporter_Id", "dbo.Users");
            DropForeignKey("dbo.Words", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Words", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.Topics", "Author_Id", "dbo.Users");
            DropIndex("dbo.Words", new[] { "TopicId" });
            DropIndex("dbo.Words", new[] { "AuthorId" });
            DropIndex("dbo.Topics", new[] { "Author_Id" });
            DropIndex("dbo.Reports", new[] { "Reporter_Id" });
            DropIndex("dbo.Reports", new[] { "WordId" });
            DropIndex("dbo.Reports", new[] { "TopicId" });
            DropTable("dbo.Words");
            DropTable("dbo.Topics");
            DropTable("dbo.Users");
            DropTable("dbo.Reports");
            DropTable("dbo.BadWords");
        }
    }
}
