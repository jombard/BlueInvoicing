namespace BlueInvoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.Invoices", new[] { "Client_ClientId" });
            AlterColumn("dbo.Clients", "ClientName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Clients", "Address", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Clients", "ContactEmail", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Clients", "InvoiceEmail", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Invoices", "InvoiceNumber", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.Invoices", "Client_ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoices", "Client_ClientId");
            AddForeignKey("dbo.Invoices", "Client_ClientId", "dbo.Clients", "ClientId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.Invoices", new[] { "Client_ClientId" });
            AlterColumn("dbo.Invoices", "Client_ClientId", c => c.Int());
            AlterColumn("dbo.Invoices", "InvoiceNumber", c => c.String());
            AlterColumn("dbo.Clients", "InvoiceEmail", c => c.String());
            AlterColumn("dbo.Clients", "ContactEmail", c => c.String());
            AlterColumn("dbo.Clients", "Address", c => c.String());
            AlterColumn("dbo.Clients", "ClientName", c => c.String());
            CreateIndex("dbo.Invoices", "Client_ClientId");
            AddForeignKey("dbo.Invoices", "Client_ClientId", "dbo.Clients", "ClientId");
        }
    }
}
