namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 50, unicode: false),
                        Lastname = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 255, unicode: false),
                        Company = c.String(nullable: false, maxLength: 255, unicode: false),
                        Visibility = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Reason = c.String(maxLength: 8000, unicode: false),
                        Active = c.Boolean(nullable: false),
                        User = c.String(nullable: false, maxLength: 8000, unicode: false),
                        CustomerId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.DetailLine",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Item = c.String(nullable: false, maxLength: 50, unicode: false),
                        PricePiece = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 4, scale: 2),
                        CountOfItems = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                        VatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.VAT", t => t.VatId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.VatId);
            
            CreateTable(
                "dbo.VAT",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Percentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetailLine", "VatId", "dbo.VAT");
            DropForeignKey("dbo.DetailLine", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.Invoice", "CustomerId", "dbo.Customer");
            DropIndex("dbo.DetailLine", new[] { "VatId" });
            DropIndex("dbo.DetailLine", new[] { "InvoiceId" });
            DropIndex("dbo.Invoice", new[] { "CustomerId" });
            DropTable("dbo.VAT");
            DropTable("dbo.DetailLine");
            DropTable("dbo.Invoice");
            DropTable("dbo.Customer");
        }
    }
}
