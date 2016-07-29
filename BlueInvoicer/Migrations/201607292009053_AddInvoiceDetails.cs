namespace BlueInvoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoiceDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "InvoiceDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Invoices", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "PurchaseOrder", c => c.String(maxLength: 10));
            AddColumn("dbo.Invoices", "DateRemittanceReceived", c => c.DateTime(nullable: false));
            AddColumn("dbo.Invoices", "Notes", c => c.String(maxLength: 1024));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "Notes");
            DropColumn("dbo.Invoices", "DateRemittanceReceived");
            DropColumn("dbo.Invoices", "PurchaseOrder");
            DropColumn("dbo.Invoices", "Amount");
            DropColumn("dbo.Invoices", "InvoiceDate");
        }
    }
}
