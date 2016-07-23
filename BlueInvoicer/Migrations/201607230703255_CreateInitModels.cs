namespace BlueInvoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInitModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        Address = c.String(),
                        ContactEmail = c.String(),
                        InvoiceEmail = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.String(),
                        Raised = c.Boolean(nullable: false),
                        Paid = c.Boolean(nullable: false),
                        Client_ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId)
                .Index(t => t.Client_ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.Invoices", new[] { "Client_ClientId" });
            DropTable("dbo.Invoices");
            DropTable("dbo.Clients");
        }
    }
}
