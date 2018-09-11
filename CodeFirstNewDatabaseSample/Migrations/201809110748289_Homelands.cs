namespace CodeFirstNewDatabaseSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Homelands : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Organizations", "OrgsCountryId", "dbo.Countries");
            DropIndex("dbo.Organizations", new[] { "OrgsCountryId" });
            CreateTable(
                "dbo.OrganizationCountries",
                c => new
                    {
                        Organization_OrganizationId = c.Int(nullable: false),
                        Country_CountryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Organization_OrganizationId, t.Country_CountryId })
                .ForeignKey("dbo.Organizations", t => t.Organization_OrganizationId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.Country_CountryId, cascadeDelete: true)
                .Index(t => t.Organization_OrganizationId)
                .Index(t => t.Country_CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrganizationCountries", "Country_CountryId", "dbo.Countries");
            DropForeignKey("dbo.OrganizationCountries", "Organization_OrganizationId", "dbo.Organizations");
            DropIndex("dbo.OrganizationCountries", new[] { "Country_CountryId" });
            DropIndex("dbo.OrganizationCountries", new[] { "Organization_OrganizationId" });
            DropTable("dbo.OrganizationCountries");
            CreateIndex("dbo.Organizations", "OrgsCountryId");
            AddForeignKey("dbo.Organizations", "OrgsCountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
        }
    }
}
