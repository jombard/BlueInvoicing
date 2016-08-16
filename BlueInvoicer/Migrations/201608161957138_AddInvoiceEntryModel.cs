namespace BlueInvoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoiceEntryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 1024),
                        Amount = c.Int(nullable: false),
                        Invoice_Id = c.Int(),
                        RateType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.Invoice_Id)
                .ForeignKey("dbo.RateTypes", t => t.RateType_Id)
                .Index(t => t.Invoice_Id)
                .Index(t => t.RateType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceEntries", "RateType_Id", "dbo.RateTypes");
            DropForeignKey("dbo.InvoiceEntries", "Invoice_Id", "dbo.Invoices");
            DropIndex("dbo.InvoiceEntries", new[] { "RateType_Id" });
            DropIndex("dbo.InvoiceEntries", new[] { "Invoice_Id" });
            DropTable("dbo.InvoiceEntries");
        }
    }
}
