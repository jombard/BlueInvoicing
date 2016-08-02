namespace BlueInvoicer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToInvoice : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Invoices", name: "Client_ClientId", newName: "ClientId");
            RenameIndex(table: "dbo.Invoices", name: "IX_Client_ClientId", newName: "IX_ClientId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Invoices", name: "IX_ClientId", newName: "IX_Client_ClientId");
            RenameColumn(table: "dbo.Invoices", name: "ClientId", newName: "Client_ClientId");
        }
    }
}
