namespace CodeFirstNewDatabaseSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Tags = c.String(),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        FromPostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Posts", t => t.FromPostId, cascadeDelete: true)
                .Index(t => t.FromPostId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Long(nullable: false, identity: true),
                        CountryName = c.String(),
                        CountryCode = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        OrganizationId = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(),
                        OrgsCountryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.OrganizationId)
                .ForeignKey("dbo.Countries", t => t.OrgsCountryId, cascadeDelete: true)
                .Index(t => t.OrgsCountryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        display_name = c.String(),
                        UsersOrgId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Username)
                .ForeignKey("dbo.Organizations", t => t.UsersOrgId, cascadeDelete: true)
                .Index(t => t.UsersOrgId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UsersOrgId", "dbo.Organizations");
            DropForeignKey("dbo.Organizations", "OrgsCountryId", "dbo.Countries");
            DropForeignKey("dbo.Comments", "FromPostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Users", new[] { "UsersOrgId" });
            DropIndex("dbo.Organizations", new[] { "OrgsCountryId" });
            DropIndex("dbo.Comments", new[] { "FromPostId" });
            DropIndex("dbo.Posts", new[] { "BlogId" });
            DropTable("dbo.Users");
            DropTable("dbo.Organizations");
            DropTable("dbo.Countries");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.Blogs");
        }
    }
}
